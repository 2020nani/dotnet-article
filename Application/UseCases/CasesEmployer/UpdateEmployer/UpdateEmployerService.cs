using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.CustomException;

namespace FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer
{
    public class UpdateEmployerService : IUpdateEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly ILogger<UpdateEmployerService> _logger;


        public UpdateEmployerService(IEmployerRepository repository, ILogger<UpdateEmployerService> logger)
        {
            this._employerRepository = repository;
            _logger = logger;
        }

        UpdateEmployerOutput IUpdateEmployerService.Execute(UpdateEmployerInput input)
        {
            UpdateEmployerOutput output = new UpdateEmployerOutput();
            Employer actualEmployer = _employerRepository.FindEmployer(input.Id).Result;
            if (actualEmployer == null)
            {
                _logger.LogInformation($"Usuario com id: {input.Id} nao encontrado");
                throw new AppNotFoundException($"Usuario com id: {input.Id} nao encontrado");
            };
            Employer newData = _employerRepository.UpdateEmployer(input.Convert(actualEmployer)).Result;
            return output.Convert(newData);
        }
    }
}
