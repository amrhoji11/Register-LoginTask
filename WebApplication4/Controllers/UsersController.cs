using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplecationDbContext context;

        public UsersController(ApplecationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var check = context.Users.Where(a => a.UserName == user.UserName && a.Password == user.Password);
            if (check.Any())
            {
                return RedirectToAction("Index", "Employees");
            }
            ViewBag.error = "Invalid UserName/Password";

            return View(user);

        }

        public IActionResult Active(Guid id)
        {
            var emp = context.Users.Find(id);
            emp.isActive = true;

            context.SaveChanges();


            return RedirectToAction("Index", "Employees");

        }


    }
}
