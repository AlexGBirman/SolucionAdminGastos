using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminGastos.Models;

namespace AdminGastos.Controllers
{
    public class OperacionesConConceptoController : Controller
    {
        private readonly GastosContext _context;

        public OperacionesConConceptoController(GastosContext context)
        {
            _context = context;
        }

        // GET: OperacionesConConcepto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gastos.ToListAsync());
        }

        // GET: OperacionesConConcepto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacion = await _context.Gastos
                .FirstOrDefaultAsync(m => m.IdOperacion == id);
            if (operacion == null)
            {
                return NotFound();
            }

            return View(operacion);
        }

        // GET: OperacionesConConcepto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OperacionesConConcepto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOperacion,importe,Producto,Fecha,concepto")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operacion);
        }

        // GET: OperacionesConConcepto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacion = await _context.Gastos.FindAsync(id);
            if (operacion == null)
            {
                return NotFound();
            }
            return View(operacion);
        }

        // POST: OperacionesConConcepto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOperacion,importe,Producto,Fecha,concepto")] Operacion operacion)
        {
            if (id != operacion.IdOperacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperacionExists(operacion.IdOperacion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(operacion);
        }

        // GET: OperacionesConConcepto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacion = await _context.Gastos
                .FirstOrDefaultAsync(m => m.IdOperacion == id);
            if (operacion == null)
            {
                return NotFound();
            }

            return View(operacion);
        }

        // POST: OperacionesConConcepto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operacion = await _context.Gastos.FindAsync(id);
            _context.Gastos.Remove(operacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperacionExists(int id)
        {
            return _context.Gastos.Any(e => e.IdOperacion == id);
        }
    }
}
