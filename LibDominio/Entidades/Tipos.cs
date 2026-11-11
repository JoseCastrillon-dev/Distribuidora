using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibDominio.entidades
{
    public class Tipos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Especie { get; set; }

        [NotMapped] public List<Carnes>? _carne { get; set; }


    }
}
