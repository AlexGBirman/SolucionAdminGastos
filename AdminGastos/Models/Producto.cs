using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminGastos.Models
{
    public class Producto
    {
        public string nombre { get; private set; }
        public double importe { get; private set; }
        public ConceptoCompra concepto { get; private set; }
    }
}
