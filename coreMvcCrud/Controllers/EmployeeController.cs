using coreMvcCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreMvcCrud.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {

            return View(Repository.AllEmpoyees);
        }
        public IActionResult Create()
        {
            
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> departments = new()
            {
                new SelectListItem { Value = "1", Text = "Development" },
                new SelectListItem { Value = "2", Text = "QA" ,Selected=true},
                new SelectListItem { Value = "3", Text = "Test" },
                new SelectListItem { Value = "4", Text = "Analysis" },
                new SelectListItem { Value = "5", Text = "Devops" },
                new SelectListItem { Value = "6", Text = "HelpDesk" },
                
            };

            //assigning SelectListItem to view Bag
            ViewBag.departments = departments;
            return View();
        }
  
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Repository.Create(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Update(string empname)
        {
            Employee employee=Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee, string empname)
        {
            if (ModelState.IsValid)
            {
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Age = employee.Age;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Salary = employee.Salary;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Department = employee.Department;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Sex = employee.Sex;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Name = employee.Name;

                return RedirectToAction("Index");
            }
            else
                return View();
        }
        public IActionResult ViewRecord(string empname)
        {
            Employee employee=Repository.AllEmpoyees.Where(e=>e.Name == empname).FirstOrDefault();    
            return View(employee);
        }
    }
}
