using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FirstApi.Application.CustomValidations
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is string))
            {
                return new ValidationResult("Password must be not null");
            }

            var password = value as string;
            var hasUpperCaseLetter = new Regex(@"[A-Z]+");
            var hasLowerCaseLetter = new Regex(@"[a-z]+");
            var hasDigit = new Regex(@"[0-9]+");
            var hasSpecialCharacter = new Regex(@"[\W]+");

            if (password.Length < 8 ||
                !hasUpperCaseLetter.IsMatch(password) ||
                !hasLowerCaseLetter.IsMatch(password) ||
                !hasDigit.IsMatch(password) ||
                !hasSpecialCharacter.IsMatch(password))
            {
                return new ValidationResult("Password must be at least 8 characters long and contain an uppercase letter, a lowercase letter, a number, and a special character.");
            }

            return ValidationResult.Success;
        }
    }
}
