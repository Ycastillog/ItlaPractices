using DAL;
using Models;
using System.Data.SqlClient;

namespace BLL
{
    public class InquilinoBLL
    {
        public void AgregarInquilino(Inquilino inquilino)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Inquilino (Nombre, Cedula, Telefono) OUTPUT INSERTED.InquilinoID VALUES (@Nombre, @Cedula, @Telefono)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", inquilino.Nombre);
                cmd.Parameters.AddWithValue("@Cedula", inquilino.Cedula);
                cmd.Parameters.AddWithValue("@Telefono", inquilino.Telefono);

                try
                {
                    // Ejecutamos el comando y obtenemos el ID insertado
                    inquilino.InquilinoID = (int)cmd.ExecuteScalar();  // Aquí obtenemos el ID generado
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar el inquilino: {ex.Message}");
                }
            }
        }
    }
}