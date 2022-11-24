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
    }
}
