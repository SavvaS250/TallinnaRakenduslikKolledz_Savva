using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

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
            ViewData["SelectAction"] = "Create";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
               // PopulateDepartmentDropDownList(course.DepartmentID);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["SelectAction"] = "DeleteDetails";
            return View("DeleteDetails", course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);

            if (course != null)
            {
                _context.Courses.Remove(course);
                
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }
            ViewData["SelectAction"] = "Details";
            return View("DeleteDetails", course);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses
                .Include(d => d.Department)
                .FirstOrDefaultAsync(d => d.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["SelectAction"] = "Edit";
            return View("Create", course);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmEdit([Bind("CourseId,Title,Credits,DepartmentID")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(course);
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
