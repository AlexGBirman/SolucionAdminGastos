using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminGastos.Models
{
    public class Mes
    {
        public string mes { get; private set; }
        public List<Operacion> operaciones { get; private set; }
        public List<Resumen> resumenes { get; private set; }
        public double efectivoActual { get; private set; }
        public double dineroEnCuentaActual { get; private set; }
        public int fechaDeCierre { get; private set; }


    public Mes(string mes)
        {
            this.mes = mes;
            this.operaciones = new();
            this.resumenes = new();
            this.dineroEnCuentaActual = 0;
            this.efectivoActual = 0;
            this.fechaDeCierre = 0;

        }

        public agregarOperacion()
    }
}
