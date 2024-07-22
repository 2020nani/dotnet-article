

using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Application.UseCases.CasesEmployer.DeleteEmployer
{
    public class DeleteEmployerService : IDeleteEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly ILogger<DeleteEmployerService> _logger;

        public DeleteEmployerService(IEmployerRepository employerRepository, ILogger<DeleteEmployerService> logger)
        {
            _employerRepository = employerRepository;
            _logger = logger;
        }

        string IDeleteEmployerService.DeleteEmployer(int id)
        {
            try
            {
                Employer employer = _employerRepository.FindEmployer(id).Result;
                _employerRepository.DeleteEmployer(employer);
                return "Deleted by success";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error by delete employer with id {id}");
                _logger.LogError(ex.Message);
                return $"Error by delete employer with id {id}";
            }
        }
    }
}
