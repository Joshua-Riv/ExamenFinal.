using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoReciclaje.modelo
{
    public class cls_reciclaje
    {
        public int id { get; set; }
        public int usuario { get; set; }
        public int tipo { get; set; }
        public decimal cantidad { get; set; }
        public DateTime fecha { get; set; }

        public string nombreUsuario { get; set; }
        public string nombreTipo { get; set; }
    }
}