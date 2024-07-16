

using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Application.UseCases.CasesEmployer.DeleteEmployer
{
    public class DeleteEmployerService : IDeleteEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public DeleteEmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
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
                return $"Error by delete employer with id {id}";
            }
        }
    }
}
