using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public class DbCategoriesRepository : IDbCategoriesRepository
    {
        public PizzeriaDbContext db = PizzeriaDbContext.Instance;

        public DbCategoriesRepository()
        {

        }

        public List<Category>? All()
        {
            return db.Categories.ToList();
        }
    }
}
