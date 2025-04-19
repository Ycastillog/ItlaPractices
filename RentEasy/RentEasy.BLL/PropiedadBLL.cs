using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL
{
    public class PropiedadBLL
    {
        private Conexion conexion = new Conexion();

        public void AgregarPropiedad(Propiedad propiedad)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Propiedades (Direccion, Tipo, Precio) VALUES (@direccion, @tipo, @precio)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@direccion", propiedad.Direccion);
                cmd.Parameters.AddWithValue("@tipo", propiedad.Tipo);
                cmd.Parameters.AddWithValue("@precio", propiedad.Precio);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
