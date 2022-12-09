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
using Microsoft.AspNetCore.Identity;

namespace EmpregaSENAI.Controllers
{
    public class VagasController : Controller
    {
        private readonly AppCont _context;
        public readonly UserManager<Users> _userManager;
        public VagasController(
            AppCont context,
            UserManager<Users> userManager
        )
        {
            _userManager = userManager;
            _context = context;

        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {

            return View(await _context.Vaga.ToListAsync());
        }

        // GET: Vagas/Details/5
        [Authorize(Policy = $"{Constants.Policies.Empresa}")]
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
        [Authorize(Policy = $"{Constants.Policies.Empresa}")]
        public async Task<IActionResult> Create([Bind("Id,UserId,Desc,Setor,Requisitos,Infos, UserEmail, UserNome")] Vaga vaga)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var userId = await _userManager.GetUserIdAsync(user);
            var userNome = await _userManager.GetUserNameAsync(user);
            var userEmail = await _userManager.GetEmailAsync(user);

            /*vaga.UserEmail = userEmail;
            vaga.UserNome = userNome;*/
            vaga.UserId = userId;

            if (ModelState.IsValid)
            {                
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaga);
        }

        // GET: Vagas/Edit/5
        [Authorize(Policy = $"{Constants.Policies.Empresa}")]
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
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userId = await _userManager.GetUserIdAsync(user);

            if (userId != vaga.UserId)
            {

                return RedirectToAction(nameof(Index));
            }
            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = $"{Constants.Policies.Empresa}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Desc,Setor,Requisitos,Infos, UserEmail, UserNome")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var userNome = await _userManager.GetUserNameAsync(user);
            var userEmail = await _userManager.GetEmailAsync(user);

            /*vaga.UserEmail = userEmail;
            vaga.UserNome = userNome;*/
            vaga.UserId = userId;

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
        [Authorize(Policy = $"{Constants.Policies.Empresa}")]
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
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var userId = await _userManager.GetUserIdAsync(user);

            if (userId != vaga.UserId)
            {                     
                return RedirectToAction(nameof(Index));
            }

            return View(vaga);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = $"{Constants.Policies.Empresa}")]
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
