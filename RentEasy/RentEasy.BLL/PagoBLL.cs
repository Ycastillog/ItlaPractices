using DAL;
using Models;
using System.Collections.Generic;

namespace BLL
{
    public class PagoBLL
    {
        private PagoDAL dal = new PagoDAL();

        public void RegistrarPago(Pago pago)
        {
            dal.InsertarPago(pago); // Aquí es donde estaba el error
        }

        public void ModificarPago(Pago pago)
        {
            dal.ActualizarPago(pago);
        }

        public void EliminarPago(int pagoID)
        {
            dal.EliminarPago(pagoID);
        }

        public List<Pago> ObtenerPagos()
        {
            return dal.ObtenerPagos();
        }
    }
}

