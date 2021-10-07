using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminGastos.Models
{
    public class Anio
    {
        public int anio { get; private set; }
        public double efectivo { get; private set; }
        public double plataEnCuenta { get; private set; }
        public double ahorros { get; private set; }
    }
}
