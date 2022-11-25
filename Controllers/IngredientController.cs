using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {
        public PizzeriaDbContext db = PizzeriaDbContext.Instance;
        public IngredientController() : base()
        {

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

        public IActionResult Update(int id)
        {
            Ingredient ingredient = db.Ingredients.Where(i => i.Id == id).FirstOrDefault();
            return View(ingredient);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Ingredient formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Id = id;
                return View(formData);
            }

            Ingredient ingredient = db.Ingredients.Where(i => i.Id == id).FirstOrDefault();
            if (ingredient == null)
                return NotFound();

            ingredient.Name = formData.Name;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Ingredient ingredient = db.Ingredients.Where(i => i.Id == id).FirstOrDefault();

            db.Ingredients.Remove(ingredient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
