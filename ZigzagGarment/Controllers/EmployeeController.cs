using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ZigzagGarment.Data;
using ZigzagGarment.Models;

namespace ZigzagGarment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> objEmployeeList = _db.Employees;
            return View(objEmployeeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee objEmployee)
        {
            var allEmployeesNo = _db.Employees.Select(x => x.EmpNo).ToList();
            int count = 0;
            int employeeNo = objEmployee.EmpNo;
            //string mobilePattern = @"^(?:7|0|(?:\+94))[0-9]{8,9}$";
            //string nicPattern = @"^([0 - 9]{ 9 }[x | X | v | V] |[0 - 9]{ 12})$";
            ////Regex regexMobileNo = new Regex(@"^(?:7|0|(?:\+94))[0-9]{9,10}$");
            ////Regex regexNIC = new Regex();

            while (employeeNo > 0)
            {
                employeeNo = employeeNo / 10;
                count++;
            }

            
                foreach (var empNo in allEmployeesNo)
                {
                    if (objEmployee.EmpNo == empNo)
                    {
                        ModelState.AddModelError("name", "Entered Employee Number is Existed");
                    }
                }
           
             if (count > 5 || count < 5)
            {
                ModelState.AddModelError("name", "Employee Number shoulbe 05 Digit");
            }
            if ((DateTime.Today.Year - objEmployee.BirthOfDate.Year) < 18)
            {
                ModelState.AddModelError("name", "Below 18 years old Employee cannot be Insert");
            }
            if (!Regex.IsMatch(objEmployee.NICNo, @"^[0-9]{9}[vVxX]$") && !Regex.IsMatch(objEmployee.NICNo, @"^[0-9]{7}[0][0-9]{4}$"))
            {
                ModelState.AddModelError("name", "NIC No is not valid");
            }
            if (!Regex.IsMatch((objEmployee.MobileNo).ToString(), @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
            {
                ModelState.AddModelError("name", "Mobile No is not valid");

            }
            if (ModelState.IsValid)
            {
                _db.Employees.Add(objEmployee);
                EmployeeExperience objEmpExpeirence = new EmployeeExperience();
                objEmpExpeirence.EmpNo = objEmployee.EmpNo;
                objEmpExpeirence.EmpName = objEmployee.EmpName;
                objEmpExpeirence.Company = "";
                objEmpExpeirence.Position = "";
                objEmpExpeirence.StartYear = 0;
                objEmpExpeirence.EndYear = 0;
                objEmpExpeirence.Experience = 0;
                _db.EmployeeExperiences.Add(objEmpExpeirence);
                _db.SaveChanges();

                TempData["success"] = "Employee has been saved successfully !";
                return RedirectToAction("Index");
            }
            return View(objEmployee);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null | id == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.Employees.Find(id);
            //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(u=>u.Id == id);
            //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);
            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee objEmployee)
        {
            var allEmployeesNo = _db.Employees.Select(x => x.EmpNo).ToList();
            int count = 0;
            int employeeNo = objEmployee.EmpNo;
           
            if ((DateTime.Today.Year - objEmployee.BirthOfDate.Year) < 18)
            {
                ModelState.AddModelError("name", "Below 18 years old Employee cannot be Insert");
            }
            if (!Regex.IsMatch(objEmployee.NICNo, @"^[0-9]{9}[vVxX]$") && !Regex.IsMatch(objEmployee.NICNo, @"^[0-9]{7}[0][0-9]{4}$"))
            {
                ModelState.AddModelError("name", "NIC No is not valid");
            }
            if (!Regex.IsMatch((objEmployee.MobileNo).ToString(), @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
            {
                ModelState.AddModelError("name", "Mobile No is not valid");

            }

            if (ModelState.IsValid) 
            {
                _db.Employees.Update(objEmployee);
                _db.SaveChanges();
                TempData["success"] = "Employee has been Updated successfully";
                return RedirectToAction("Index");
            }
            return View(objEmployee);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
            {
                return NotFound();
            }
            var employeeFromDb = _db.Employees.Find(id);
            //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(u=>u.Id == id);
            //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Employee has been deleted successfully !";
            return RedirectToAction("Index");

        }

        public IActionResult Search(string? name)
        {
            if (name == null)
            {
                return NotFound();
            }
            
            var employeeFromDb = _db.Employees.Find(name);
            //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(u=>u.Id == id);
            //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }

    
    }
}
