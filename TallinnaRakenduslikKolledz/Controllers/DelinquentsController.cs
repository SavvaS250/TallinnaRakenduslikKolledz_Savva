using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;
        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var delinquents = await _context.Delinquents.ToListAsync();
            return View(delinquents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateDelinquentDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Add(delinquent);
                await _context.SaveChangesAsync();
                PopulateDelinquentDropDownList(delinquent.DelincuentID);
            }
            return RedirectToAction("Index");
        }

        private void PopulateDelinquentDropDownList(object selectDelinquent = null)
        {
            var delinquentsQuerty = from d in _context.Delinquents
                                    orderby d.Violation
                                    select d;
            ViewBag.DepartmentID = new SelectList(delinquentsQuerty.AsNoTracking(), selectDelinquent);
        }
    }
}
