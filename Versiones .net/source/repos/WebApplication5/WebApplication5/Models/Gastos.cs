using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastosApp.Models
{
    public class Gastos
    {
        
        public DateTime Fecha { get; set; }
        public int Tipo { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

    }
}