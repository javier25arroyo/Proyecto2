using System.Collections;

namespace DTOs.ProyectoDTOs
{
    public class Membresia : BaseEntity
    {
        public List<Impuesto> Impuesto { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

    }
}
