using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpregaSENAI.Areas.Identity.Data;
using EmpregaSENAI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using EmpregaSENAI.Core;

namespace EmpregaSENAI.Controllers
{
    public class CurriculosController : Controller
    {
        private readonly AppCont _context;
        private readonly UserManager<Users> _userManager;

        public CurriculosController(
            AppCont context,
            UserManager<Users> userManager
        )
        {
            _userManager = userManager;
            _context = context;

        }

        // GET: Curriculos
        [Authorize(Policy = Constants.Policies.Aluno)]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("VOCÊ NÃO ESTÁ LOGADO");
            }
            var userId = await _userManager.GetUserIdAsync(user);
            var curriculo = await _context.Curriculo.Where(x => x.FK_UserId == userId).ToListAsync();


            return View(curriculo);
        }

        // GET: Curriculos/Details/5
        [Authorize(Policy = Constants.Policies.Aluno)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Curriculo == null)
            {
                return NotFound();
            }

            var curriculo = await _context.Curriculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curriculo == null)
            {
                return NotFound();
            }

            return View(curriculo);
        }

        // GET: Curriculos/Create
        [Authorize(Policy = Constants.Policies.Aluno)]
        public async Task<IActionResult> Create()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var userId = await _userManager.GetUserIdAsync(user);
            var curriculo = await _context.Curriculo.Where(x => x.FK_UserId == userId).CountAsync();

            if (curriculo > 0)
            {
                return NotFound("Você já possui Curriculo criado");
            }
            else
            {
                return View();
            }

        }

        // POST: Curriculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = Constants.Policies.Aluno)]
        public async Task<IActionResult> Create([Bind("Id,FK_UserId,Nome,DataNascimento,Telefone,Endereco,Bairro,Cidade,CEP,Email,CargoInteresse,Instituicao,GrauFormacao,NomeCurso,Duracao,AnoConclusao, Resumo")] Curriculo curriculo)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var userId = await _userManager.GetUserIdAsync(user);
            curriculo.FK_UserId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(curriculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curriculo);


        }

        // GET: Curriculos/Edit/5
        [Authorize(Policy = Constants.Policies.Aluno)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Curriculo == null)
            {
                return NotFound();
            }

            var curriculo = await _context.Curriculo.FindAsync(id);
            if (curriculo == null)
            {
                return NotFound();
            }
            return View(curriculo);
        }

        // POST: Curriculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = Constants.Policies.Aluno)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FK_UserId,Nome,DataNascimento,Telefone,Endereco,Bairro,Cidade,CEP,Email,CargoInteresse,Instituicao,GrauFormacao,NomeCurso,Duracao,AnoConclusao, Resumo")] Curriculo curriculo)
        {
            if (id != curriculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculoExists(curriculo.Id))
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
            return View(curriculo);
        }

        // GET: Curriculos/Delete/5
        [Authorize(Policy = Constants.Policies.Aluno)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Curriculo == null)
            {
                return NotFound();
            }

            var curriculo = await _context.Curriculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curriculo == null)
            {
                return NotFound();
            }

            return View(curriculo);
        }

        // POST: Curriculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = Constants.Policies.Aluno)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Curriculo == null)
            {
                return Problem("Entity set 'AppCont.Curriculo'  is null.");
            }
            var curriculo = await _context.Curriculo.FindAsync(id);
            if (curriculo != null)
            {
                _context.Curriculo.Remove(curriculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculoExists(int id)
        {
            return _context.Curriculo.Any(e => e.Id == id);
        }
    }
}
