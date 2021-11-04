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
        public double importe { get; set; }

        public virtual String Producto { get; set; } //establece la relación de 1 a 1
        
        [Required(ErrorMessage = "Ingrese la fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public ConceptoGasto concepto { get; set; }

    }
}
