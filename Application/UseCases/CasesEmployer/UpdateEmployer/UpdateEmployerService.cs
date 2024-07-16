using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer
{
    public class UpdateEmployerService : IUpdateEmployerService
    {
        private IEmployerRepository repository;

        public UpdateEmployerService(IEmployerRepository repository)
        {
            this.repository = repository;
        }

        UpdateEmployerOutput IUpdateEmployerService.Execute(UpdateEmployerInput input)
        {
            UpdateEmployerOutput output = new UpdateEmployerOutput();
            Employer actualEmployer = repository.FindEmployer(input._Id).Result;
            repository.Register(input.updateEmployer(actualEmployer));
            return output.convert(actualEmployer);
        }
    }
}
