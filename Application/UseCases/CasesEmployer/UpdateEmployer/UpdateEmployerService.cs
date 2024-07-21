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
            Employer actualEmployer = _employerRepository.FindEmployer(input.Id).Result;
            if (actualEmployer == null)
            {
                throw new AppNotFoundException($"Usuario com id: {input.Id} nao encontrado");
            };
            Employer newData = _employerRepository.UpdateEmployer(input.Convert(actualEmployer)).Result;
            return output.convert(newData);
        }
    }
}
