using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;

namespace FirstApi.Application.UseCases.CasesUser.UpdateUser
{
    public class UpdateUserOutput
    {
        public int _Id { get; set; }
        public string? _Name { get; set; }
        public string? _Email { get; set; }
        public Endereco? _Endereco { get; set; }

        public UpdateUserOutput Convert(User user)
        {
            _Id = user.Id;
            _Name = user.Name;
            _Email = user.Email;
            _Endereco = user.Endereco;
            return this;
        }
    }
}
