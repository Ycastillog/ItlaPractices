using DAL;
using Models;
using System.Data.SqlClient;

namespace BLL
{
    public class InquilinoBLL
    {
        private Conexion conexion = new Conexion();

        public void AgregarInquilino(Inquilino inquilino)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Inquilinos (Nombre, Cedula, Telefono) VALUES (@nombre, @cedula, @telefono)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", inquilino.Nombre);
                cmd.Parameters.AddWithValue("@cedula", inquilino.Cedula);
                cmd.Parameters.AddWithValue("@telefono", inquilino.Telefono);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

