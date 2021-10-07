using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminGastos.Models
{
    public class Resumen
    {
        public double totalAPagar { get; private set; }
        public Tarjeta tarjeta { get; set; }
    }
}
