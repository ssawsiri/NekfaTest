using Microsoft.AspNetCore.Mvc;
using ZigzagGarment.Data;
using ZigzagGarment.Models;

namespace ZigzagGarment.Controllers
{
    public class EmployeeExperienceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeExperienceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Experience(int? empNo)
        {
            if (empNo == null | empNo == 0)
            {
                return NotFound();
            }
            var employeeFromDb = _db.EmployeeExperiences.FirstOrDefault(u => u.EmpNo == empNo);

            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }

        public IActionResult AddExperience(int empNo)
        {
            return View();
        }

    }
}
