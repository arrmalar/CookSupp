using System.ComponentModel.DataAnnotations;

namespace CookSupp.Models.CustomValidationAttributes
{
    public class UserNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var username = value as string;
            
            if (username != null && username.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return new ValidationResult("Username must not contain special characters.");
            }

            return ValidationResult.Success;
        }
    }
}
