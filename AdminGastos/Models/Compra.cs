using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminGastos.Models
{
    public class Compra:Operacion
    {
        public MedioDePago medioDePago { get; private set; }
        public List<Producto> productos { get; private set; }

    }
}
