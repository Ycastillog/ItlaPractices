using DAL;
using Models;
using System;
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
                    inquilino.InquilinoID = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar el inquilino: {ex.Message}");
                }
            }
        }

        public void ModificarInquilino(Inquilino inquilino)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "UPDATE Inquilino SET Nombre = @Nombre, Cedula = @Cedula, Telefono = @Telefono WHERE InquilinoID = @InquilinoID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@InquilinoID", inquilino.InquilinoID);
                cmd.Parameters.AddWithValue("@Nombre", inquilino.Nombre);
                cmd.Parameters.AddWithValue("@Cedula", inquilino.Cedula);
                cmd.Parameters.AddWithValue("@Telefono", inquilino.Telefono);

                try
                {
                    cmd.ExecuteNonQuery();  // Ejecutamos la actualización
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al modificar el inquilino: {ex.Message}");
                }
            }
        }

        public void EliminarInquilino(int inquilinoID)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "DELETE FROM Inquilino WHERE InquilinoID = @InquilinoID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@InquilinoID", inquilinoID);

                try
                {
                    cmd.ExecuteNonQuery();  // Ejecutamos la eliminación
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar el inquilino: {ex.Message}");
                }
            }
        }
    }
}
