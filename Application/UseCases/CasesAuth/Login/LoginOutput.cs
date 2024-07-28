using FirstApi.Domain.Entities;

namespace FirstApi.Application.UseCases.CasesAuth.Login
{
    public class LoginOutput
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? AccessToken { get; set; }

        internal LoginOutput Convert(User user, string token)
        {
            Id = user.Id;
            UserName = user.Name;
            AccessToken = token;
            return this;
        }
    }
}
