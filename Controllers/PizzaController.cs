using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<Pizza> lista = db.Pizze.Include(pizza => pizza.Category).ToList();

            return View(lista);
        }

        public IActionResult Detail(int id)
        {
            //selezione della pizza dal db secondo l'id passato
            Pizza pizza = db.Pizze.Where(p => p.Id == id).Include("Category").FirstOrDefault();

            return View(pizza);
        }

        //ritorna la view del form create
        public IActionResult Create()
        {
            //istanza
            PizzaForm formData = new PizzaForm();
            formData.Pizza = new Pizza();
            //query per recuperare le categorie
            formData.Categories = db.Categories.ToList();

            return View(formData);
        }

        //si occupa della richiesta post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                return View(formData);
            }

            db.Pizze.Add(formData.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //update
        public IActionResult Update(int id)
        {
            Pizza pizza = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();


            if (pizza == null)
                return NotFound();

            PizzaForm formData = new PizzaForm();

            formData.Pizza = pizza;
            formData.Categories = db.Categories.ToList();

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaForm formData)
        {
            formData.Pizza.Id = id;
            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                return View(formData);
            }

            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
                return NotFound();

            pizza.Name = formData.Pizza.Name;
            pizza.Description = formData.Pizza.Description;
            pizza.Photo = formData.Pizza.Photo;
            pizza.Price = formData.Pizza.Price;
            pizza.CategoryId = formData.Pizza.CategoryId;

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
