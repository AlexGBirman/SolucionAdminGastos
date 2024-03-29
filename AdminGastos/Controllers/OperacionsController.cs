﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminGastos.Models;
using System.Data;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AdminGastos.Controllers
{
    public class OperacionsController : Controller
    {
        private readonly GastosContext _context;

        public OperacionsController(GastosContext context)
        {
            _context = context;
        }

        // GET: Operacions


        [HttpPost]
        public async Task<IActionResult> IndexFiltro(double filtro)
        {
            string query = "SELECT * FROM Operacion where importe < " + filtro;
            var algo = await _context.Gastos.FromSqlRaw(query).ToListAsync();
            return View("Index",algo);
        }


        [HttpPost]
        public async Task<IActionResult> IndexOrden(string orden)
        {
            string query = "SELECT * FROM Operacion";
            var algo = await _context.Gastos.FromSqlRaw(query).ToListAsync();


            switch (orden)
            {
                case "producto":
                    algo = await _context.Gastos.FromSqlRaw(query).OrderBy(a => a.Producto).ToListAsync();
                    break;

                case "importe":
                    algo = await _context.Gastos.FromSqlRaw(query).OrderBy(a => a.importe).ToListAsync();
                    break;

                case "fecha":
                    algo = await _context.Gastos.FromSqlRaw(query).OrderBy(a => a.Fecha).ToListAsync();
                    break;

                case "concepto":
                    algo = await _context.Gastos.FromSqlRaw(query).OrderBy(a => a.Concepto).ToListAsync();
                    break;

                case "":
                    //do nothing
                    break;
            }


            return View("Index",algo);
        }


        [HttpPost]
        public async Task<IActionResult> IndexPorMes(int mes)
        {

            string query = "Select * from Operacion";
            
            if ((mes) >= 1 && (mes)<= 12)
            {
                query = "Select * from Operacion where MONTH(Fecha) = " + mes;
            }

            var algo = await _context.Gastos.FromSqlRaw(query).ToListAsync();

            return View("Index", algo);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            string query = "SELECT * FROM Operacion";

            return View(await _context.Gastos.FromSqlRaw(query).OrderBy(a => a.Fecha).ToListAsync());
        }

        // GET: Operacions/Details/5


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
            ViewBag.OpePiola = operacion;

            return View(operacion);
        }

        // GET: Operacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOperacion,importe,Producto,Concepto,Fecha")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operacion);
        }

        // GET: Operacions/Edit/5
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

        // POST: Operacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOperacion,importe,Producto,Concepto,Fecha")] Operacion operacion)
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

        // GET: Operacions/Delete/5
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

        // POST: Operacions/Delete/5
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
