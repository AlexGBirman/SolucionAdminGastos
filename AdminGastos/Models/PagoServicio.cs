using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminGastos.Models
{
    public class PagoServicio : Operacion
    {
        public ConceptoPagoServicio concepto { get; private set; }
    }
}
