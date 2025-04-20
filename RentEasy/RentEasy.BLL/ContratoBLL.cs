using DAL;
using Models;
using System;
using System.Data.SqlClient;

namespace BLL
{
    public class ContratoBLL
    {
        public void AgregarContrato(Contrato contrato)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Contrato (PropiedadID, InquilinoID, FechaInicio, FechaFin, MontoMensual) OUTPUT INSERTED.ContratoID VALUES (@PropiedadID, @InquilinoID, @FechaInicio, @FechaFin, @MontoMensual)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PropiedadID", contrato.PropiedadID);
                cmd.Parameters.AddWithValue("@InquilinoID", contrato.InquilinoID);
                cmd.Parameters.AddWithValue("@FechaInicio", contrato.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", contrato.FechaFin);
                cmd.Parameters.AddWithValue("@MontoMensual", contrato.MontoMensual);

                try
                {
                    contrato.ContratoID = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar el contrato: {ex.Message}");
                }
            }
        }

        public void ModificarContrato(Contrato contrato)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "UPDATE Contrato SET PropiedadID = @PropiedadID, InquilinoID = @InquilinoID, FechaInicio = @FechaInicio, FechaFin = @FechaFin, MontoMensual = @MontoMensual WHERE ContratoID = @ContratoID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ContratoID", contrato.ContratoID);
                cmd.Parameters.AddWithValue("@PropiedadID", contrato.PropiedadID);
                cmd.Parameters.AddWithValue("@InquilinoID", contrato.InquilinoID);
                cmd.Parameters.AddWithValue("@FechaInicio", contrato.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", contrato.FechaFin);
                cmd.Parameters.AddWithValue("@MontoMensual", contrato.MontoMensual);

                try
                {
                    cmd.ExecuteNonQuery();  // Ejecutamos la actualización
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al modificar el contrato: {ex.Message}");
                }
            }
        }

        public void EliminarContrato(int contratoID)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "DELETE FROM Contrato WHERE ContratoID = @ContratoID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ContratoID", contratoID);

                try
                {
                    cmd.ExecuteNonQuery();  // Ejecutamos la eliminación
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar el contrato: {ex.Message}");
                }
            }
        }
    }
}





