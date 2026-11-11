using System.ComponentModel.DataAnnotations.Schema;

namespace LibDominio.entidades
{
    public class Carnes
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public Decimal Peso { get; set; }

        public int id_tipo { get; set; }

        public bool Activo { get; set; }


        [ForeignKey("id_tipo")] public Tipos? _tipo { get; set; }
    }
}