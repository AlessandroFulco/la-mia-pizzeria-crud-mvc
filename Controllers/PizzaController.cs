using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        PizzeriaDbContext db;

        public PizzaController() : base()
        {
            //Collegamento con il db
            db = new PizzeriaDbContext();
        }
        public IActionResult Index()
        {
            List<Pizza> lista = db.Pizze.ToList();

            return View(lista);
        }

        public IActionResult Detail(int id)
        {
            //selezione della pizza dal db secondo l'id passato
            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            return View(pizza);
        }

        //ritorna la view del form
        public IActionResult Create()
        {
            return View("Create");
        }

        //si occupa della richiesta post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza modello)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Pizze.Add(modello);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
