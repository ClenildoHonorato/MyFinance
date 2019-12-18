using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class HomeModel
    {
        public string LerNomeUsuario()
        {
            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable("SELECT * FROM usuario");
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["Nome"].ToString();
            }

            return "Nome não encontrado!";
        }
    }
}
