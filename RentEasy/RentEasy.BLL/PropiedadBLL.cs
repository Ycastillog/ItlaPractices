using System;
using System.Data.SqlClient;
using DAL;
using Models;

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
                    propiedad.PropiedadID = (int)cmd.ExecuteScalar();  // Aquí obtenemos el ID generado
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar la propiedad: {ex.Message}");
                }
            }
        }

        public void ModificarPropiedad(Propiedad propiedad)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "UPDATE Propiedad SET Direccion = @Direccion, Tipo = @Tipo, Precio = @Precio WHERE PropiedadID = @PropiedadID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PropiedadID", propiedad.PropiedadID);
                cmd.Parameters.AddWithValue("@Direccion", propiedad.Direccion);
                cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo);
                cmd.Parameters.AddWithValue("@Precio", propiedad.Precio);

                try
                {
                    cmd.ExecuteNonQuery();  // Ejecutamos la actualización
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al modificar la propiedad: {ex.Message}");
                }
            }
        }

        public void EliminarPropiedad(int propiedadID)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "DELETE FROM Propiedad WHERE PropiedadID = @PropiedadID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PropiedadID", propiedadID);

                try
                {
                    cmd.ExecuteNonQuery();  // Ejecutamos la eliminación
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar la propiedad: {ex.Message}");
                }
            }
        }
    }
}





