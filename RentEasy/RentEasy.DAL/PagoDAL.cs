using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class PagoDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RentEasyConnectionString"].ConnectionString;

        public void InsertarPago(Pago pago)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Pago (ContratoID, FechaPago, Monto) VALUES (@ContratoID, @FechaPago, @Monto)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ContratoID", pago.ContratoID);
                cmd.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarPago(Pago pago)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Pago SET FechaPago = @FechaPago, Monto = @Monto WHERE PagoID = @PagoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PagoID", pago.PagoID);
                cmd.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarPago(int pagoID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Pago WHERE PagoID = @PagoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PagoID", pagoID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Pago> ObtenerPagos()
        {
            List<Pago> pagos = new List<Pago>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT PagoID, ContratoID, FechaPago, Monto FROM Pagos";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pagos.Add(new Pago
                    {
                        PagoID = Convert.ToInt32(reader["PagoID"]),
                        ContratoID = Convert.ToInt32(reader["ContratoID"]),
                        FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                        Monto = Convert.ToDecimal(reader["Monto"])
                    });
                }
            }
            return pagos;
        }
    }
}






