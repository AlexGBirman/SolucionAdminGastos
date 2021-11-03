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
       
        [Required(ErrorMessage = "Ingrese el importe")]
        public double Importe { get; set; }
        public virtual List<Producto> Productos { get; set; } //establece la relación de 1 a n
        
        [Required(ErrorMessage = "Ingrese la fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

    }
}
