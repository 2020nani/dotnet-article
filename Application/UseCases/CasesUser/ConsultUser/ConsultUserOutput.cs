using FirstApi.Domain.Entities;
using FirstApi.Domain.Enums;

namespace FirstApi.Application.UseCases.CasesUser.ConsultUser
{
    public class ConsultUserOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }

        public ConsultUserOutput Convert(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Roles = Roles = user.Roles.Select(x => x.ToString()).ToList();
            return this;
        }
    }
}
