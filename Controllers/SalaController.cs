using CRUD.Models;
using CRUD.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class SalaController : Controller
    {
        private readonly CoworkingContext _context;

        public SalaController(CoworkingContext context)
        {
            _context = context;
        }

        // GET: Sala
        public async Task<IActionResult> Index()
        {
            var salas = _context.Salas.Include(s => s.TipoSala);
            return View(await salas.ToListAsync());
        }

        // GET: Sala/Create
        public IActionResult Create()
        {
            ViewData["TipoSalaId"] = new SelectList(_context.TiposSala, "Id", "Nome");
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,TipoSalaId")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoSalaId"] = new SelectList(_context.TiposSala, "Id", "Nome", sala.TipoSalaId);
            return View(sala);
        }

        // GET: Sala/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var sala = await _context.Salas.FindAsync(id);
            if (sala == null) return NotFound();

            ViewData["TipoSalaId"] = new SelectList(_context.TiposSala, "Id", "Nome", sala.TipoSalaId);
            return View(sala);
        }

        // POST: Sala/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,TipoSalaId")] Sala sala)
        {
            if (id != sala.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Salas.Any(e => e.Id == sala.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["TipoSalaId"] = new SelectList(_context.TiposSala, "Id", "Nome", sala.TipoSalaId);
            return View(sala);
        }

        // GET: Sala/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var sala = await _context.Salas
                .Include(s => s.TipoSala)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (sala == null) return NotFound();

            return View(sala);
        }

        // POST: Sala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
