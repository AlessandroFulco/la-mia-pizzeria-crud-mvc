using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public class DbCategoriesRepository
    {
        public PizzeriaDbContext db = PizzeriaDbContext.Instance;

        public DbCategoriesRepository()
        {

        }

        internal List<Category>? All()
        {
            return db.Categories.ToList();
        }
    }
}
