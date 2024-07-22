using FirstApi.Application.CustomValidations;
using FirstApi.Application.UseCases.PasswordHasher;
using FirstApi.Domain.Entities;
using FirstApi.Infrastructure.Integration.ViaCep;
using System.ComponentModel.DataAnnotations;

namespace FirstApi.Application.UseCases.CasesUser.RegisterUser
{
    public class RegisterUserInput
    {
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }
        [Password(ErrorMessage = "Password must be at least 8 characters long and contain an uppercase letter, a lowercase letter, a number, and a special character.")]
        public string? Password { get; set; }
        public string? Cep { get; set; }

        public User Convert(IPasswordHasher hasher, ViaCepResponse response)
        {

            User user = new User();
            user.Name = Name;
            user.Password = hasher.Hash(Password);
            user.Email = Email;
            user.Endereco = user.GetEndereco(response);
            return user;
        }
    }
}
