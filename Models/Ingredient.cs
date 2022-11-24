namespace la_mia_pizzeria_static.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pizza>? Pizze { get; set; }

        public Ingredient()
        {

        }
        public Ingredient(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
