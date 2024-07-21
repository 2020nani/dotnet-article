using FirstApi.Domain.Entities;

namespace FirstApi.Application.UseCases.CasesUser.ConsultUser
{
    public class ConsultUserOutput
    {
        public string? _Name;
        public string? _Email;

        public ConsultUserOutput Convert(User user) {
            _Name = user.Name;
            _Email = user.Email;
            return this;    
        }
    }
}
