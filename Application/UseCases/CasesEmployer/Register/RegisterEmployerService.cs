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

        public Employer Execute(RegisterEmployerInput employerInput)
        {
            return repository.Register(employerInput.convert());
        }
    }
}
