using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public class DbPizzaRepository
    {
        private PizzeriaDbContext db;


        public DbPizzaRepository()
        {
            //collegamento con il db
            db = new PizzeriaDbContext();
        }

        public List<Pizza> All()
        {
            return db.Pizze.Include(pizza => pizza.Category).Include(pizza => pizza.Ingredients).ToList();
        }
    }
}
