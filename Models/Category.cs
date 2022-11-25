using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Category
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Devi inserire un nome")]
        public string Name { get; set; }

        public List<Pizza>? Pizze { get; set; }  

        public Category() 
        {
            
        }

        public Category(string name)
        {
            Name = name;
        }
    }
}
