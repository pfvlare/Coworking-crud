using CRUD.Models;
using CRUD.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class TipoSalaController : Controller
    {
        private readonly CoworkingContext _context;

        public TipoSalaController(CoworkingContext context)
        {
            _context = context;
        }

        // GET: TipoSala
        public async Task<IActionResult> Index()
        {
            var tipos = await _context.TiposSala.ToListAsync();
            return View(tipos);
        }

        // GET: TipoSala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Capacidade,PrecoHora")] TipoSala tipoSala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSala);
        }

        // GET: TipoSala/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TiposSala.FindAsync(id);
            if (tipoSala == null) return NotFound();

            return View(tipoSala);
        }

        // POST: TipoSala/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Capacidade,PrecoHora")] TipoSala tipoSala)
        {
            if (id != tipoSala.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TiposSala.Any(e => e.Id == tipoSala.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSala);
        }

        // GET: TipoSala/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TiposSala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoSala == null) return NotFound();

            return View(tipoSala);
        }

        // POST: TipoSala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoSala = await _context.TiposSala.FindAsync(id);
            if (tipoSala != null)
            {
                _context.TiposSala.Remove(tipoSala);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
