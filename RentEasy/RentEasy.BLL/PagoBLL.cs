using DAL;
using Models;
using System;
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

                pago.PagoID = (int)cmd.ExecuteScalar();  // Solo obtenemos el ID, no mostramos nada aquí
            }
        }

        public void ModificarPago(Pago pago)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "UPDATE Pago SET Monto = @Monto, FechaPago = @FechaPago WHERE PagoID = @PagoID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PagoID", pago.PagoID);
                cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                cmd.Parameters.AddWithValue("@FechaPago", pago.FechaPago);

                try
                {
                    cmd.ExecuteNonQuery();  // Ejecutamos la actualización
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al modificar el pago: {ex.Message}");
                }
            }
        }

        public void EliminarPago(int pagoID)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "DELETE FROM Pago WHERE PagoID = @PagoID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PagoID", pagoID);

                try
                {
                    cmd.ExecuteNonQuery();  // Ejecutamos la eliminación
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar el pago: {ex.Message}");
                }
            }
        }
    }
}

