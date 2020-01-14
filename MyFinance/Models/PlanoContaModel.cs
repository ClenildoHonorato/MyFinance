namespace MyFinance.Models
{
    using Microsoft.AspNetCore.Http;
    using MyFinance.Util;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;

    public class PlanoContaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informa a Descrição!")]
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int Usuario_Id { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public PlanoContaModel()
        {

        }

        public PlanoContaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<PlanoContaModel> ListaPLanoConta()
        {
            List<PlanoContaModel> lista = new List<PlanoContaModel>();
            PlanoContaModel item;

            string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
            string sql = $"SELECT Id, Usuario_Id, Descricao, Tipo FROM plano_contas where Usuario_Id = {usuarioLogado}";
            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                item = new PlanoContaModel();
                item.Id = int.Parse(dataTable.Rows[i]["Id"].ToString());
                item.Usuario_Id = int.Parse(dataTable.Rows[i]["Usuario_Id"].ToString());
                item.Descricao = dataTable.Rows[i]["Descricao"].ToString();
                item.Tipo = dataTable.Rows[i]["tipo"].ToString();
                lista.Add(item);
            }

            return lista;
        }

        public PlanoContaModel CarregarRegistro(int? id, string usuarioLogado)
        {
            PlanoContaModel item = new PlanoContaModel();

            //string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT Id, Usuario_Id, Descricao, Tipo FROM plano_contas where Usuario_Id = {usuarioLogado} AND Id = {id}";
            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable(sql);

            item.Id = int.Parse(dataTable.Rows[0]["Id"].ToString());
            item.Usuario_Id = int.Parse(dataTable.Rows[0]["Usuario_Id"].ToString());
            item.Descricao = dataTable.Rows[0]["Descricao"].ToString();
            item.Tipo = dataTable.Rows[0]["tipo"].ToString();

            return item;
        }

        public void InsertUpdate(string usuarioLogado)
        {
            string sql = "";

            if (Id != 0)
            {
                sql = $"UPDATE plano_contas SET Descricao = '{Descricao}', Tipo = '{Tipo}' WHERE Usuario_Id = '{usuarioLogado}' AND Id = '{Id}'";
            }
            else
            {
                sql = $"INSERT INTO plano_contas (Descricao, Tipo, Usuario_Id) VALUES ('{Descricao}','{Tipo}','{usuarioLogado}')";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }

        public void ExcluirConta(string id)
        {
            string sql = "DELETE FROM plano_contas WHERE Id = " + id;
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }

    }
}
