using Models;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class InquilinoDAL
    {
        private string conexion = "your_connection_string_here";  // Reemplaza con tu cadena de conexión

        // Método para agregar un inquilino
        public void AgregarInquilino(Inquilino inquilino)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                string query = "INSERT INTO Inquilino (Nombre, Cedula, Telefono) " +
                               "VALUES (@Nombre, @Cedula, @Telefono); " +
                               "SELECT SCOPE_IDENTITY();"; // Obtener el ID generado

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", inquilino.Nombre);
                cmd.Parameters.AddWithValue("@Cedula", inquilino.Cedula);
                cmd.Parameters.AddWithValue("@Telefono", inquilino.Telefono);

                var result = cmd.ExecuteScalar();
                inquilino.InquilinoID = Convert.ToInt32(result); // Asignar el ID generado
            }
        }
    }
}


