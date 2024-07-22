using FirstApi.Domain.Entities;

namespace FirstApi.Application.UseCases.CasesUser.ConsultUser
{
    public class ConsultUserOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public ConsultUserOutput Convert(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            return this;
        }
    }
}
