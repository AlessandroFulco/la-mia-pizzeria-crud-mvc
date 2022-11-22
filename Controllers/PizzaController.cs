using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

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

        //ritorna la view del form create
        public IActionResult Create()
        {
            return View("Create");
        }

        //si occupa della richiesta post create
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

        //update
        public IActionResult Update(int id)
        {
            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
                return NotFound();
            
            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
                return NotFound();

            pizza.Name = formData.Name;
            pizza.Description = formData.Description;
            pizza.Photo = formData.Photo;
            pizza.Price = formData.Price;


            db.SaveChanges();

            return RedirectToAction("Index");
        }


        //delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
                return NotFound();

            db.Pizze.Remove(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
