// Models/Contrato.cs
namespace Models
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        public int PropiedadId { get; set; }
        public int InquilinoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}

