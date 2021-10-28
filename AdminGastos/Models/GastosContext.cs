using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGastos.Models
{
    public class GastosContext:DbContext
    {
        public DbSet<Operacion> Gastos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OB)
        {
            OB.UseSqlServer("Data Source = DESKTOP-S9UR8V3\\SQLEXPRESS; Initial Catalog = Gastos; Integrated Security = true;");
        }
    }
}
