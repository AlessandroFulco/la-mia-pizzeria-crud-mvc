using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Validator
{
    public class MinFiveWordLength : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string findValue = (string)value;

            if(findValue == null)
            {
                return new ValidationResult("La descrizione deve contenere almeno 5 parole");
            }

            string[] stringSplitted = findValue.Split(' ');
            if(stringSplitted.Length < 5)
            {
                return new ValidationResult("La descrizione deve contenere almeno 5 parole");
            }

            return ValidationResult.Success;
        }
    }
}
