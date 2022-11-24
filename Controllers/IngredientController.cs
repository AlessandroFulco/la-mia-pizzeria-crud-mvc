using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {
        PizzeriaDbContext db;
        public IngredientController() : base()
        {
            db = new PizzeriaDbContext();
        }


        public IActionResult Index()
        {
            List<Ingredient> lista = db.Ingredients.ToList();
            return View(lista);
        }

        public IActionResult Detail(int id)
        {
            Ingredient ingredient = db.Ingredients.Where(i => i.Id == id).FirstOrDefault();
            return View(ingredient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient formData)
        {
            if (!ModelState.IsValid)
                return View(formData);

            db.Ingredients.Add(formData);
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }
    }
}
