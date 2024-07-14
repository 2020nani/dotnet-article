using FirstApi.Domain.Entities;

namespace FirstApi.Application.UseCases.CasesEmployer.Register
{
    public class RegisterEmployerOutput
    {
        public required Employer Employer { get; set; }
    }
}
