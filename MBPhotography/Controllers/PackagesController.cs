using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MBPhotography.Data;
using MBPhotography.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MBPhotography.Controllers
{
    public class PackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Packages
        public async Task<IActionResult> Index()
        {
            var list = await _context.Packages.AsNoTracking().ToListAsync();
            return View(list);
        }

        // GET: /Packages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pkg = await _context.Packages.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id.Value);
            if (pkg == null) return NotFound();

            return View(pkg);
        }

        // admin-like create/edit/delete could be added in Admin area
    }
}
