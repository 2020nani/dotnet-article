using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;

namespace FirstApi.Application.UseCases.CasesUser.RegisterUser
{
    public class RegisterUserOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Endereco? Endereco { get; set; }

        public RegisterUserOutput Convert(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Endereco = user.Endereco;
            return this;
        }
    }
}
