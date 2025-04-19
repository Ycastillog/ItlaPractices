namespace Models
{
    public class Contrato
    {
        public int ContratoID { get; set; }
        public int PropiedadID { get; set; }
        public int InquilinoID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal MontoMensual { get; set; }
    }
}
