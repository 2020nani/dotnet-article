using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Application.UseCases.CasesEmployer.Register
{
    public class RegisterEmployerService : IRegisterEmployerService
    {
        private IEmployerRepository _employerRepository;
        public RegisterEmployerService(IEmployerRepository repository)
        {
            this._employerRepository = repository;
        }

        public RegisterEmployerOutput Execute(RegisterEmployerInput employerInput)
        {
            RegisterEmployerOutput output = new RegisterEmployerOutput();
            output.Employer = _employerRepository.Register(employerInput.Convert()).Result;
            return output;
        }
    }
}
