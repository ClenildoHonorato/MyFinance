namespace MyFinance.Util
{
    using MySql.Data.MySqlClient;
    using System.Data;

    public class DAL
    {
        private static string server = "localhost";
        private static string database = "financeiro";
        private static string user = "root";
        private static string password = "";
        private string connectionString = $"Server={server}; Database={database}; Uid={user}; Pwd={password}; convert zero datetime=True";
        private MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public void ExecutarComandoSql(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }

    //public class dbConnection
    //{

    //    public SqlDataAdapter adapter;

    //    public SqlConnection conection;

    //    public SqlCommand myCommand;



    //    public dbConnection()

    //    {

    //        adapter = new SqlDataAdapter();

    //        conection = new SqlConnection(@"Data Source=LEVI-PC\SQLEXPRESS;Initial Catalog=Teste_One;Integrated Security=True");

    //    }

    //    private SqlConnection Abrir_conecao()

    //    {

    //        if (conection.State == ConnectionState.Closed || conection.State == ConnectionState.Broken)

    //        {

    //            conection.Open();

    //        }



    //        return conection;

    //    }
    //}
}
