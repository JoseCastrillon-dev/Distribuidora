using System;
using System.Collections.Generic;
using System.Text;

namespace LibDominio.entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public String? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }

    }
}