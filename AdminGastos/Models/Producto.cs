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
<<<<<<< HEAD
        public int id { get;  set; }
        public string nombre { get;  set; }
        public double importe { get;  set; }
        public ConceptoGasto concepto { get; set; }
=======
        public int IdProducto { get; set; }
        public int IdOperacion { get; set; } //debe existir para establecer la relación con Operacion
        public string Nombre { get; set; }
        public double Importe { get; set; }
        public ConceptoGasto Concepto { get; set; }
>>>>>>> 36bc05833ed1ebc490b01df6e4cf91eebd17173a
    }
}
