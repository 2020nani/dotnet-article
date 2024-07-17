using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.CustomException;

namespace FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer
{
    public class UpdateEmployerService : IUpdateEmployerService
    {
        private IEmployerRepository _employerRepository;

        public UpdateEmployerService(IEmployerRepository repository)
        {
            this._employerRepository = repository;
        }

        UpdateEmployerOutput IUpdateEmployerService.Execute(UpdateEmployerInput input)
        {
            UpdateEmployerOutput output = new UpdateEmployerOutput();
            Employer actualEmployer = _employerRepository.FindEmployer(input._Id).Result;
            if (actualEmployer == null)
            {
                throw new AppNotFoundException($"Usuario com id: {input._Id} nao encontrado");
            };
            Employer newData = _employerRepository.UpdateEmployer(input.updateEmployer(actualEmployer)).Result;
            return output.convert(newData);
        }
    }
}
