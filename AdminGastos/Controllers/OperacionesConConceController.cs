﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminGastos.Models;

namespace AdminGastos.Controllers
{
    public class OperacionesConConceController : Controller
    {
        private readonly GastosContext _context;

        public OperacionesConConceController(GastosContext context)
        {
            _context = context;
        }

        // GET: OperacionesConConce
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gastos.ToListAsync());
        }

        // GET: OperacionesConConce/Details/5
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

        // GET: OperacionesConConce/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OperacionesConConce/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOperacion,importe,Producto,Fecha")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operacion);
        }

        // GET: OperacionesConConce/Edit/5
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

        // POST: OperacionesConConce/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOperacion,importe,Producto,Fecha")] Operacion operacion)
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

        // GET: OperacionesConConce/Delete/5
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

        // POST: OperacionesConConce/Delete/5
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