using Microsoft.AspNetCore.Mvc;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}
