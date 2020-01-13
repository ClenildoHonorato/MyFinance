using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class ContaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome da Conta!")]
        public string Nome { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Saldo { get; set; }
        public int Usuario_Id { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public ContaModel()
        {

        }

        public ContaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<ContaModel> ListaConta()
        {
            List<ContaModel> lista = new List<ContaModel>();
            ContaModel item;

            string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
            string sql = $"SELECT Id, Nome, Saldo, Usuario_Id FROM Conta where Usuario_Id = {usuarioLogado}";
            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                item = new ContaModel();
                item.Id = int.Parse(dataTable.Rows[i]["Id"].ToString());
                item.Nome = dataTable.Rows[i]["Nome"].ToString();
                item.Saldo = double.Parse(dataTable.Rows[i]["Saldo"].ToString());
                item.Usuario_Id = int.Parse(dataTable.Rows[i]["Usuario_Id"].ToString());
                lista.Add(item);
            }

            return lista;
        }

        public void Insert(string usuarioLogado)
        {
            string sql = $"INSERT INTO Conta (Nome, Saldo, Usuario_Id) VALUES ('{Nome}','{Saldo}','{usuarioLogado}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }

        public void ExcluirConta(string id)
        {
            string sql = "DELETE FROM Conta WHERE Id = " + id;
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }
    }
}
