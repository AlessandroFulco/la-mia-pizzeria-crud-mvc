namespace la_mia_pizzeria_static.Models.Repositories
{
    public class InMemoryPizzaRepository : IDbPizzaRepository
    {
        public static List<Pizza> Pizze = new List<Pizza>();

        public List<Pizza> All()
        {
            return Pizze;
        }

        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Id = Pizze.Count;
            pizza.Category = new Category() { Id = 1, Name = "Fake Category" };
            pizza.Ingredients = new List<Ingredient>();

            IngredientsToPizza(pizza, selectedIngredients);
            Pizze.Add(pizza);
        }

        private static void IngredientsToPizza(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Category = new Category() { Id = 1, Name = "Fake Category" };

            foreach(int ingredientId in selectedIngredients)
            {
                pizza.Ingredients.Add(new Ingredient() { Id = ingredientId, Name = "Fake Tag " + ingredientId });
            }
        }

        public void Delete(Pizza pizza)
        {
            Pizze.Remove(pizza);
        }

        public Pizza GetById(int id)
        {
            Pizza pizza = Pizze.Where(pizze => pizze.Id == id).FirstOrDefault();

            pizza.Category = new Category() { Id = 1, Name = "Fake Category" };

            return pizza;
        }

        public void Update(Pizza pizza, Pizza formData, List<int> selectedIngredients)
        {
            pizza = formData;

            pizza.Category = new Category() { Id = 1, Name = "Fake Category" };

            pizza.Ingredients = new List<Ingredient>();
            IngredientsToPizza(pizza, selectedIngredients);
        }
    }
}
