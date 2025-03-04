namespace DTOs
{
    public class Oferta : BaseEntity
    {
        public Usuario Oferente { get; set; }
        public Licitacion Licitacion { get; set; }
        public string Estado { get; set; }
        public double Precio { get; set; }
        public List<Producto> Producto { get; set; }
    }
}
