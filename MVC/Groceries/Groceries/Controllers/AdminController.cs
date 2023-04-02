using Groceries.Data;
using Groceries.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Groceries.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db= db;
        }
       public bool checkAdmin() {
            string role = Request.Cookies["role"];
            return role == "AD007";
        }

        public IActionResult Index()
        {

            if (checkAdmin())
            {
                IEnumerable<Grocerie> groceries= _db.GroceriesTable;
                return View(groceries);
            }
            return RedirectToAction("Login","Auth");
        }

        public IActionResult AddGrocerie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGrocerie(Grocerie grocerie)
        {
            if (checkAdmin())
            {
                _db.GroceriesTable.Add(grocerie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return RedirectToAction("Login", "Auth");
            }
        }

        public IActionResult ViewGrocerie(int ?id) {
            if (checkAdmin())
            {
                Grocerie selectedGrocerie = _db.GroceriesTable.Find(id);
                return View(selectedGrocerie);
            }
            else { 
            return RedirectToAction("Login"); 
            }

        }
        public IActionResult EditGrocerie(int?id)
        {
            if (checkAdmin())
            {
               Grocerie grocerie= _db.GroceriesTable.Find(id);
                return View(grocerie);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public IActionResult EditGrocerie(Grocerie grocerie )
        {
            if (checkAdmin())
            {
                 _db.GroceriesTable.Update(grocerie);
                _db.SaveChanges();
                return RedirectToAction("ViewGrocerie", "Admin",new {id=grocerie.id });
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public IActionResult DeleteGrocerie(int? id) {
            if (checkAdmin())
            {
                Grocerie grocerie = _db.GroceriesTable.Find(id);
                _db.Remove<Grocerie>(grocerie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return RedirectToAction("Login", "Auth");
            }
        }

    }
}
