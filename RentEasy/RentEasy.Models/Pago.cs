namespace Models
{
    public class Pago
    {
        public int PagoID { get; set; }
        public int ContratoID { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; } // Aquí corregido
    }
}


