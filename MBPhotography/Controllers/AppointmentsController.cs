using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MBPhotography.Data;
using MBPhotography.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MBPhotography.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Appointments
        public async Task<IActionResult> Index()
        {
            var list = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Package)
                .Include(a => a.SessionType)
                .AsNoTracking()
                .ToListAsync();

            return View(list);
        }

        // GET: /Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Package)
                .Include(a => a.SessionType)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id.Value);

            if (appointment == null) return NotFound();

            return View(appointment);
        }

        // GET: /Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (!ModelState.IsValid) return View(appointment);

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments.FindAsync(id.Value);
            if (appointment == null) return NotFound();

            return View(appointment);
        }

        // POST: /Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id) return BadRequest();
            if (!ModelState.IsValid) return View(appointment);

            _context.Update(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments
                .Include(a => a.Customer)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id.Value);

            if (appointment == null) return NotFound();

            return View(appointment);
        }

        // POST: /Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
