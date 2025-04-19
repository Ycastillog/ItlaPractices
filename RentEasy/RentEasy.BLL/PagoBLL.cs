// BLL/PagoBLL.cs
using DAL;
using Models;
using System.Data.SqlClient;

namespace BLL
{
    public class PagoBLL
    {
        private Conexion conexion = new Conexion();

        public void RegistrarPago(Pago pago)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Pagos (ContratoId, FechaPago, Monto) VALUES (@contrato, @fecha, @monto)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@contrato", pago.ContratoId);
                cmd.Parameters.AddWithValue("@fecha", pago.FechaPago);
                cmd.Parameters.AddWithValue("@monto", pago.Monto);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

