using DAL;
using Models;
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
    }
}




