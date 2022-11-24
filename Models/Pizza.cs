using la_mia_pizzeria_static.Validator;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        //validation
        [Required(ErrorMessage = "Il nome deve essere inserito")]
        [StringLength(30, ErrorMessage = "Il nome non può superare più di 30 caratteri")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descrizione deve essere inserita")]
        [StringLength(200, ErrorMessage = "La descrizione non può superare più di 200 caratteri")]
        [MinFiveWordLength]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Il link della foto deve essere inserito")]
        [StringLength(100, ErrorMessage = "Il link della foto non può superare più di 100 caratteri")]
        [Url]
        public string Photo { get; set; }

        [Range(1 , 99.9 , ErrorMessage = "Il prezzo deve essere minimo 1 euro e massimo 99.99")]
        public double Price { get; set; }

        // relazione 1 a n con category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        //relazione n a n con ingredient
        public List<Ingredient>? Ingredients { get; set; }

        public Pizza()
        {

        }

        public Pizza(int id, string name, string description, string photo, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Photo = photo;
            Price = price;
        }
    }
}
