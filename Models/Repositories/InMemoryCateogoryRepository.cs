namespace la_mia_pizzeria_static.Models.Repositories
{
    public class InMemoryCateogoryRepository : IDbCategoriesRepository
    {
        public List<Category> Categories = new List<Category>();

        public List<Category>? All()
        {
            return Categories;
        }
    }
}
