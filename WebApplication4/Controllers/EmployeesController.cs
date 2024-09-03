using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplecationDbContext _context;

        public EmployeesController(ApplecationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var emp = _context.Users.Where(a => a.isActive == false).ToList();


            return View(emp);
        }
        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Store(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);

            return View(emp);
        }
        public IActionResult Update(Employee emp)
        {
            var employee = _context.Employees.Find(emp.Id);
            employee.Name = emp.Name;
            employee.Email = emp.Email;
            if (emp.Password is not null)
                employee.Password = emp.Password;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
