using Groceries.Data;
using Groceries.Models;
using Microsoft.AspNetCore.Mvc;

namespace Groceries.Controllers
{
    public class AuthController : Controller
    {
        ApplicationDbContext _db;
        public AuthController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Login() {
            return View();
         }

        public string getRoleCode(string userRole) {
            Dictionary<string,string> role = new Dictionary<string,string>();
            role.Add("admin", "AD007");
            role.Add("user","US009");
            return role[userRole];
        }
        [HttpPost]
        public IActionResult Login(User options)
        {
            var email = options.Email;
            var password = options.Password;
            try
            {
                var userDetails = (from x in _db.UsersTable where x.Email == email select x).FirstOrDefault();
                if (userDetails != null)
                {
                    if (userDetails.Password == password)
                    {
                        CookieOptions cookie = new CookieOptions();
                        cookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Append("Role", getRoleCode(userDetails.Role));
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        TempData["error"] = "invlaid";
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    TempData["error"] = "invlaid";
                    return RedirectToAction("Login");
                }

            }
            catch (Exception)
            {
                RedirectToAction("Error", "Home");
                throw;
            }
          
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            _db.UsersTable.Add(user);
            _db.SaveChanges();
            Console.WriteLine(user);
           return RedirectToAction("Login");
      
        }

    }
}
