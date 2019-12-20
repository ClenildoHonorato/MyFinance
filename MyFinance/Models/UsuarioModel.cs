namespace MyFinance.Models
{
    using MyFinance.Util;
    using System;
    using System.Data;

    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Data_Nascimento { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"SELECT * FROM usuario where Email='{Email}' AND Senha='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable(sql);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Id = int.Parse(dataTable.Rows[0]["ID"].ToString());
                Nome = dataTable.Rows[0]["NOME"].ToString();
                Data_Nascimento = DateTime.Parse(dataTable.Rows[0]["DATA_NASCIMENTO"].ToString());

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
