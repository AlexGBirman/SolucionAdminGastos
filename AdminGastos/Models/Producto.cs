using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminGastos.Models
{
    public class Producto
    {
        [Key]
        public int id { get;  set; }
        public string nombre { get;  set; }
        public double importe { get;  set; }
        public ConceptoGasto concepto { get; set; }
    }
}
