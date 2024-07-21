using FirstApi.Application.UseCases.PasswordHasher;
using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;
using FirstApi.Infrastructure.Integration.ViaCep;

namespace FirstApi.Application.UseCases.CasesUser.RegisterUser
{
    public class RegisterUserInput
    {
        public string? _Name { get; set; }
        public required string _Email { get; set; }
        public required string _Password { get; set; }
        public string? _Cep { get; set; }

        public User Convert(IPasswordHasher hasher, ViaCepResponse response)
        {

            User user = new User();
            user.Name = _Name;
            user.Password = hasher.Hash(_Password);
            user.Email = _Email;
            user.Endereco = user.GetEndereco(response);
            return user;
        }
    }
}
