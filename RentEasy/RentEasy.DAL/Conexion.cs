using System.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=RentEasy;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}



