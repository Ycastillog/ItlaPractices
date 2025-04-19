using Models;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class PropiedadDAL
    {
        private string conexion = "your_connection_string_here";  // Reemplaza con tu cadena de conexión

        // Método para agregar una propiedad
        public void AgregarPropiedad(Propiedad propiedad)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                string query = "INSERT INTO Propiedad (Direccion, Tipo, Precio) " +
                               "VALUES (@Direccion, @Tipo, @Precio); " +
                               "SELECT SCOPE_IDENTITY();"; // Obtener el ID generado

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Direccion", propiedad.Direccion);
                cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo);
                cmd.Parameters.AddWithValue("@Precio", propiedad.Precio);

                var result = cmd.ExecuteScalar();
                propiedad.PropiedadID = Convert.ToInt32(result); // Asignar el ID generado
            }
        }
    }
}
