using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Application.UseCases.CasesEmployer.Register
{
    public class RegisterEmployerService : IRegisterEmployerService
    {
        private IEmployerRepository repository;
        public RegisterEmployerService(IEmployerRepository repository)
        {
            this.repository = repository;
        }

        public RegisterEmployerOutput Execute(RegisterEmployerInput employerInput)
        {
            RegisterEmployerOutput output = new RegisterEmployerOutput();
            output.Employer = repository.Register(employerInput.convert());
            return output;
        }
    }
}
