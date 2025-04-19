using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Conexion
    {
        public SqlConnection GetConnection()
        {
            try
            {
                // Obtener la cadena de conexión desde el archivo de configuración
                string connectionString = ConfigurationManager.ConnectionStrings["RentEasyConnectionString"].ConnectionString;

                // Crear y devolver la conexión
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                // Mostrar detalles completos del error
                Console.WriteLine("Error al establecer la conexión: " + ex.Message);
                throw new Exception("Error al establecer la conexión con la base de datos: " + ex.ToString());
            }
        }
    }
}



