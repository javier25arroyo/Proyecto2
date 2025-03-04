using DTOs.ProyectoDTOs;

namespace DTOs
{
    public class Producto : BaseEntity
    {
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public int Cantidad { get; set; }
        public List<Impuesto> Impuestos { get; set; }
    }
}
