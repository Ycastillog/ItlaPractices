using DAL;
using Models;
using System.Data.SqlClient;

namespace BLL
{
    public class PropiedadBLL
    {
        public void AgregarPropiedad(Propiedad propiedad)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Propiedad (Direccion, Tipo, Precio) OUTPUT INSERTED.PropiedadID VALUES (@Direccion, @Tipo, @Precio)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Direccion", propiedad.Direccion);
                cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo);
                cmd.Parameters.AddWithValue("@Precio", propiedad.Precio);

                try
                {
                    // Ejecutamos el comando y obtenemos el ID insertado
                    propiedad.PropiedadID = (int)cmd.ExecuteScalar();  // Aquí obtenemos el ID generado
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar la propiedad: {ex.Message}");
                }
            }
        }
    }
}

