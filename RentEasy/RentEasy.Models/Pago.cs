// Models/Pago.cs
namespace Models
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int ContratoId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
    }
}

