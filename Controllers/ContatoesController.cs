﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaMVC.Data;
using AgendaMVC.Models;

namespace AgendaMVC.Controllers
{
    public class ContatoesController : Controller
    {
        private readonly AgendaMVCContext _context;

        public ContatoesController(AgendaMVCContext context)
        {
            _context = context;
        }

        // GET: Contatoes
        public async Task<IActionResult> Index()
        {
              return _context.Contato != null ? 
                          View(await _context.Contato.ToListAsync()) :
                          Problem("Entity set 'AgendaMVCContext.Contato'  is null.");
        }

        // GET: Contatoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contatoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        // GET: Contatoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        // POST: Contatoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Contato contato)
        {
            if (id != contato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.Id))
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
            return View(contato);
        }

        // GET: Contatoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contato == null)
            {
                return Problem("Entity set 'AgendaMVCContext.Contato'  is null.");
            }
            var contato = await _context.Contato.FindAsync(id);
            if (contato != null)
            {
                _context.Contato.Remove(contato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
          return (_context.Contato?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
