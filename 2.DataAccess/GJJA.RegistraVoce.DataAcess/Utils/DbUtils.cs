using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace GJJA.RegistraVoce.DataAcess.Utils
{
    public class DbUtils
    {
        public static DbConnection CreateConnection(string connectionString)
        {
            //cada banco tem o seu  provider            
            //(https://www.connectionstrings.com/) esse site diz as strings para acessar

            DbConnection connection = new MySqlConnection(connectionString); // string de acesso aso banco
            connection.Open();  // abre a conexao com banco de dados
            return connection;
        }

        public static void CloseConnection(DbConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

    }
}