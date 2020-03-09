namespace MyFinance.Models
{
    using Microsoft.AspNetCore.Http;
    using MyFinance.Util;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;

    public class TransacaoModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string DataFinal { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int Conta_Id { get; set; }
        public int Plano_Contas_Id { get; set; }
        public string NomeConta { get; set; }
        public string DescricaoPlano { get; set; }


        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public TransacaoModel()
        {

        }

        public TransacaoModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<TransacaoModel> ListaTransacao()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            TransacaoModel item;

            //Utilizado pela View Extrato
            string filtro = "";
            if((Data != null) && (DataFinal != null))
                filtro += $" and t.Data >= '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}' and t.Data <= '{DateTime.Parse(DataFinal).ToString("yyyy/MM/dd")}'";

            if (Tipo != null && Tipo != "A")
                filtro += $" and t.Tipo ='{Tipo}'";

            if (Conta_Id != 0)
            {
                filtro += $" and t.Conta_Id = '{Conta_Id}' ";
            }
            //Fim

            string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
            string sql = "SELECT t.Id, t.Data,t.Tipo, t.Valor, t.Descricao as historico,t.Conta_Id, " +
                          "c.Nome as conta, t.Plano_Contas_Id, p.Descricao as plano_conta " +
                          "FROM transacao as t inner join conta c on t.Conta_Id = c.Id inner join plano_contas as p " +
                          $"on t.Plano_Contas_Id = p.Id where t.Usuario_Id = {usuarioLogado} {filtro} order by t.data desc limit 10";

            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                item = new TransacaoModel();
                item.Id = int.Parse(dataTable.Rows[i]["Id"].ToString());
                item.Data = dataTable.Rows[i]["Data"].ToString();
                item.Tipo = dataTable.Rows[i]["Tipo"].ToString();
                item.Valor = Decimal.Parse(dataTable.Rows[i]["Valor"].ToString());
                item.Descricao = dataTable.Rows[i]["historico"].ToString();
                item.Conta_Id = int.Parse(dataTable.Rows[i]["Conta_Id"].ToString());
                item.NomeConta = dataTable.Rows[i]["conta"].ToString();
                item.Plano_Contas_Id = int.Parse(dataTable.Rows[i]["Plano_Contas_Id"].ToString());
                item.DescricaoPlano = dataTable.Rows[i]["plano_conta"].ToString();
                lista.Add(item);
            }

            return lista;
        }

        public void InsertUpdate(string usuarioLogado)
        {
            string sql = "";

            if (Id != 0)
            {
                sql = $"UPDATE transacao SET Data='{Data}', Tipo = '{Tipo}', Valor = '{Valor}', Descricao = '{Descricao}' WHERE Usuario_Id = '{usuarioLogado}' AND Id = '{Id}'";
            }
            else
            {
                sql = $"INSERT INTO transacao (Data, Tipo, Valor, Descricao, Conta_Id, Plano_Contas_Id, Usuario_Id) VALUES ('{Data}','{Tipo}','{Valor}','{Descricao}','{Conta_Id}','{Plano_Contas_Id}',{usuarioLogado})";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }

        public TransacaoModel CarregarRegistro(int? id, string usuarioLogado)
        {

            TransacaoModel transacaoModel;

            string sql = "SELECT t.Id, t.Data,t.Tipo, t.Valor, t.Descricao as historico,t.Conta_Id, " +
                          "c.Nome as conta, t.Plano_Contas_Id, p.Descricao as plano_conta " +
                          "FROM transacao as t inner join conta c on t.Conta_Id = c.Id inner join plano_contas as p " +
                          $"on t.Plano_Contas_Id = p.Id where t.Usuario_Id = {usuarioLogado} AND t.Id = {id} order by t.data desc limit 10";

            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable(sql);


            transacaoModel = new TransacaoModel();
            transacaoModel.Id = int.Parse(dataTable.Rows[0]["Id"].ToString());
            transacaoModel.Data = dataTable.Rows[0]["Data"].ToString();
            transacaoModel.Tipo = dataTable.Rows[0]["Tipo"].ToString();
            transacaoModel.Valor = Decimal.Parse(dataTable.Rows[0]["Valor"].ToString());
            transacaoModel.Descricao = dataTable.Rows[0]["historico"].ToString();
            transacaoModel.Conta_Id = int.Parse(dataTable.Rows[0]["Conta_Id"].ToString());
            transacaoModel.NomeConta = dataTable.Rows[0]["conta"].ToString();
            transacaoModel.Plano_Contas_Id = int.Parse(dataTable.Rows[0]["Plano_Contas_Id"].ToString());
            transacaoModel.DescricaoPlano = dataTable.Rows[0]["plano_conta"].ToString();


            return transacaoModel;
        }


        public void Excluir(string id)
        {
            string sql = "DELETE FROM transacao WHERE Id = " + id;
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }

    }

    public class Dashboard
    {
        public double Total { get; set; }
        public string PlanoConta { get; set; }

        public List<Dashboard> RetornarGraficoPie()
        {
            List<Dashboard> lista = new List<Dashboard>();
            Dashboard item;

            string sql = "select sum(t.valor) as total, p.Descricao from transacao as t inner join plano_contas as p " +
                         "on t.Plano_Contas_Id = p.Id where t.Tipo = 'D' group by p.Descricao";

            DAL objDAL = new DAL();
            DataTable dt = new DataTable();
            dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Dashboard();
                item.Total = double.Parse(dt.Rows[i]["Total"].ToString());
                item.PlanoConta = dt.Rows[i]["Descricao"].ToString();
                lista.Add(item);
            }

            return lista;


        }
    }
}
