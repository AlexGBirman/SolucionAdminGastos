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
        public int IdProducto { get; set; }
        public int IdOperacion { get; set; } //debe existir para establecer la relación con Operacion
        public string Nombre { get; set; }
        public double Importe { get; set; }
        public ConceptoGasto Concepto { get; set; }
    }
}
