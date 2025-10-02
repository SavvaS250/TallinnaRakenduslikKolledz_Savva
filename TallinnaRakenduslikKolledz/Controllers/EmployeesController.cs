using Microsoft.AspNetCore.Mvc;
using TallinnaRakenduslikKolledz.Data;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly SchoolContext _context;
        public EmployeesController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
