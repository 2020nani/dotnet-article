
using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.CustomException;

namespace FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer
{
    public class ConsultEmployerService : IConsultEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly ILogger<ConsultEmployerService> _logger;

        public ConsultEmployerService(IEmployerRepository employerRepository, ILogger<ConsultEmployerService> logger)
        {
            _employerRepository = employerRepository;
            _logger = logger;
        }

        ConsultEmployerOutput IConsultEmployerService.FindEmployerById(int id)
        {
            ConsultEmployerOutput output = new ConsultEmployerOutput();
            Employer employer = _employerRepository.FindEmployer(id).Result;
            if (employer == null)
            {
                _logger.LogInformation("Employer is null");
                throw new AppNotFoundException($"Employer com id: {id} nao encontrado");
            };
            return output.Convert(employer);
        }

        List<ConsultEmployerOutput> IConsultEmployerService.FindEmployers()
        {
            ConsultEmployerOutput output = new ConsultEmployerOutput();
            return _employerRepository.FindEmployers().Result
                .ConvertAll(
                new Converter<Employer, ConsultEmployerOutput>(obj => output.Convert(obj))
                );
        }
    }
}
