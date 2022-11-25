using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        //public DbPizzaRepository pizzaRepository;
        //public DbIngredientsRepository ingredientsRepository;
        //public DbCategoriesRepository categoriesRepository;

        public IDbPizzaRepository pizzaRepository;
        public IDbIngredientsRepository ingredientsRepository;
        public IDbCategoriesRepository categoriesRepository;


        public PizzaController(IDbPizzaRepository _pizzaRepository, IDbIngredientsRepository _ingredientsRepository, IDbCategoriesRepository _categoriesRepository) : base()
        {
            //pizzaRepository = new DbPizzaRepository();
            //ingredientsRepository = new DbIngredientsRepository();
            //categoriesRepository = new DbCategoriesRepository();

            pizzaRepository = _pizzaRepository;
            ingredientsRepository = _ingredientsRepository;
            categoriesRepository = _categoriesRepository;
            
        }
        public IActionResult Index()
        {
            //List<Pizza> lista = db.Pizze.Include(pizza => pizza.Category).ToList();
            List<Pizza> lista = pizzaRepository.All();

            return View(lista);
        }

        public IActionResult Detail(int id)
        {
            //selezione della pizza dal db secondo l'id passato
            //Pizza pizza = db.Pizze.Where(p => p.Id == id).Include("Category").FirstOrDefault();
            Pizza pizza = pizzaRepository.GetById(id);

            return View(pizza);
        }

        //ritorna la view del form create
        public IActionResult Create()
        {
            //istanza
            PizzaForm formData = new PizzaForm();
            formData.Pizza = new Pizza();
            formData.Categories = categoriesRepository.All();
            formData.Ingredients = new List<SelectListItem>();

            List<Ingredient> Ingredients = ingredientsRepository.All();
            foreach(Ingredient item in Ingredients)
            {
                formData.Ingredients.Add(new SelectListItem(item.Name, item.Id.ToString()));
            }

            return View(formData);
        }

        //si occupa della richiesta post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Categories = categoriesRepository.All();
                formData.Ingredients = new List<SelectListItem>();

                List<Ingredient> lista = ingredientsRepository.All();

                foreach (Ingredient item in lista)
                {
                    formData.Ingredients.Add(new SelectListItem(item.Name, item.Id.ToString()));
                }

                return View(formData);
            }

            pizzaRepository.Create(formData.Pizza, formData.SelectedIngredients);

            return RedirectToAction("Index");
        }

        //update
        public IActionResult Update(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);

            if (pizza == null)
                return NotFound();
            
            PizzaForm formData = new PizzaForm();
            
            formData.Pizza = pizza;
            formData.Categories = categoriesRepository.All();
            formData.Ingredients = new List<SelectListItem>();

            List<Ingredient> ingredients = ingredientsRepository.All();

            foreach (Ingredient item in ingredients)
            {
                formData.Ingredients.Add(new SelectListItem(
                    item.Name,
                    item.Id.ToString(),
                    pizza.Ingredients.Any(i => i.Id == item.Id)
                    ));
            }

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaForm formData)
        {
            
            if (!ModelState.IsValid)
            {
                formData.Pizza.Id = id;
                formData.Categories = categoriesRepository.All();

                List<Ingredient> lista = ingredientsRepository.All();
                foreach (Ingredient item in lista)
                {
                    formData.Ingredients.Add(new SelectListItem(item.Name, item.Id.ToString()));
                }

                return View(formData);
            }

            Pizza pizza = pizzaRepository.GetById(id);

            pizzaRepository.Update(pizza, formData.Pizza, formData.SelectedIngredients);

            return RedirectToAction("Index");
        }

        //delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);

            if (pizza == null)
                return NotFound();

            pizzaRepository.Delete(pizza);

            return RedirectToAction("Index");
        }
    }
}
