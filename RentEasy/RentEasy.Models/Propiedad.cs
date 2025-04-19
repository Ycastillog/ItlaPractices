namespace Models
{
    public class Propiedad
    {
        public int PropiedadID { get; set; }  // Este es el ID que se generará automáticamente en la base de datos
        public string Direccion { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
    }
}



