namespace la_mia_pizzeria_static.Models.Repositories
{
    public class InMemoryIngredientRepository : IDbIngredientsRepository
    {
        public List<Ingredient> Ingredients = new List<Ingredient>();

        public List<Ingredient> All()
        {
            Ingredient ingredient = new Ingredient() { Id = 1, Name = "Fake Ingredient" };
            Ingredients.Add(ingredient);
            return Ingredients.ToList();
        }

        public Ingredient GetById(int ingredientId)
        {
            return Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
        }
    }
}
