using FirstApi.Domain.Entities;

namespace FirstApi.Application.UseCases.CasesUser.ConsultUser
{
    public class ConsultUserOutput
    {
        public string? Name;
        public string? Email;

        public ConsultUserOutput Convert(User user) {
            Name = user.Name;
            Email = user.Email;
            return this;    
        }
    }
}
