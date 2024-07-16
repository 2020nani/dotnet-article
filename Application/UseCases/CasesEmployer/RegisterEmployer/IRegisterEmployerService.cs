using FirstApi.Domain.Entities;

namespace FirstApi.Application.UseCases.CasesEmployer.Register
{
    public interface IRegisterEmployerService
    {
        public RegisterEmployerOutput Execute(RegisterEmployerInput employerInput);
    }
}
