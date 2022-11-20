using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpregaSENAI.Areas.Identity.Data;
using EmpregaSENAI.Models;
using Microsoft.AspNetCore.Authorization;
using EmpregaSENAI.Core;

namespace EmpregaSENAI.Controllers
{
    public class VagasController : Controller
    {
        private readonly AppCont _context;

        public VagasController(AppCont context)
        {
            _context = context;
        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vaga.ToListAsync());
        }

        // GET: Vagas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vaga == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vaga
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // GET: Vagas/Create
        [Authorize(Policy = $"{Constants.Policies.Empresa}")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Desc,Setor,Requisitos,Infos")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaga);
        }

        // GET: Vagas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vaga == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vaga.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }
            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Desc,Setor,Requisitos,Infos")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaExists(vaga.Id))
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
            return View(vaga);
        }

        // GET: Vagas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vaga == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vaga
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vaga == null)
            {
                return Problem("Entity set 'AppCont.Vaga'  is null.");
            }
            var vaga = await _context.Vaga.FindAsync(id);
            if (vaga != null)
            {
                _context.Vaga.Remove(vaga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaExists(int id)
        {
            return _context.Vaga.Any(e => e.Id == id);
        }
    }
}
