using System.Net.Http.Headers;
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
            Array enumList = Enum.GetValues(typeof(Violation));
            List<Violation> violations = new List<Violation>();
            foreach (Violation violation in enumList)
            {
                violations.Add(violation);
            }
            Array enumList2 = Enum.GetValues(typeof(DelinquentType));
            List<DelinquentType> delinquentTypes = new List<DelinquentType>();
            foreach (DelinquentType delinquent in enumList2)
            {
                delinquentTypes.Add(delinquent);
            }
            ViewBag.DelinquentTypes = new SelectList(delinquentTypes);
            ViewBag.Violations = new SelectList(violations);
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
                
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(m => m.DelincuentID == id);
            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(m => m.DelincuentID == id);
            if (delinquent == null)
            {
                return NotFound();
            }
            
            return View(delinquent);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("DelincuentID,LastName,FirstName,Violation,DelinquentType,Description")] Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Update(delinquent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(delinquent);
        }
    }
}
