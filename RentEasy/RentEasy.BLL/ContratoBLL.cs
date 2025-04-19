// BLL/ContratoBLL.cs
using DAL;
using Models;
using System.Data.SqlClient;

namespace BLL
{
    public class ContratoBLL
    {
        private Conexion conexion = new Conexion();

        public void AgregarContrato(Contrato contrato)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Contratos (PropiedadId, InquilinoId, FechaInicio, FechaFin) VALUES (@prop, @inq, @ini, @fin)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@prop", contrato.PropiedadId);
                cmd.Parameters.AddWithValue("@inq", contrato.InquilinoId);
                cmd.Parameters.AddWithValue("@ini", contrato.FechaInicio);
                cmd.Parameters.AddWithValue("@fin", contrato.FechaFin);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

