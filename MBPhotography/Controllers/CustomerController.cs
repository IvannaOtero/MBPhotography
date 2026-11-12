using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MBPhotography.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using MBPhotography.Data.Models;

namespace MBPhotography.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Customer
        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await _context.Customers.AsNoTracking().ToListAsync();
            return View(customers);
        }
    }
}
