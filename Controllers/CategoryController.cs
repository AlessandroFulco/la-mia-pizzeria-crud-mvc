using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        PizzeriaDbContext db;
        public CategoryController()
        {
            db = new PizzeriaDbContext();
        } 
        public IActionResult Index()
        {
            List<Category> lista = db.Categories.ToList();
            return View(lista);
        }

        public IActionResult Detail(int id) 
        {
            Category category = db.Categories.Where(category => category.Id == id).FirstOrDefault();
            return View(category);
        }
    }
}
