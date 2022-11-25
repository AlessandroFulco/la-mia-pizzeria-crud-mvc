namespace la_mia_pizzeria_static.Models.Repositories
{
    public interface IDbCategoriesRepository
    {
        List<Category>? All();
    }
}