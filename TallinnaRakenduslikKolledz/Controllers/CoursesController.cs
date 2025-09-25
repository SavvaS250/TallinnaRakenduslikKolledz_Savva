using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department).AsNoTracking();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateDepartmentDropDownList();
            return View();
        }

        private void PopulateDepartmentDropDownList(object selectDepartment = null)
        {
            var departmentsQuerty = from d in _context.Departments
                                    orderby d.Name
                                    select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuerty.AsNoTracking(), "DepartmentID", "Name", selectDepartment);
        }
    }
}
