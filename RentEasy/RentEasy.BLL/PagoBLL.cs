using DAL;
using Models;
using System.Data.SqlClient;

namespace BLL
{
    public class PagoBLL
    {
        public void AgregarPago(Pago pago)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Pago (ContratoID, Monto, FechaPago) OUTPUT INSERTED.PagoID VALUES (@ContratoID, @Monto, @FechaPago)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ContratoID", pago.ContratoID);
                cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                cmd.Parameters.AddWithValue("@FechaPago", pago.FechaPago);

                try
                {
                    pago.PagoID = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar el pago: {ex.Message}");
                }
            }
        }
    }
}


