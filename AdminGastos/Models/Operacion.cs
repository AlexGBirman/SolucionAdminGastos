using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminGastos.Models
{   

    public partial class Operacion
    {
        [Key]
        public int IdOperacion { get; set; }
        public double importe { get; set; }
        public List<Producto> productos { get; set; }
        public DateTime Fecha { get; set; }

    }
}
