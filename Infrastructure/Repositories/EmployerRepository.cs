using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        Employer IEmployerRepository.Register(Employer employer)
        {
            return employer;
        }

        Task<string> IEmployerRepository.DeleteEmployer(int id)
        {
            throw new NotImplementedException();
        }

        Task<Employer> IEmployerRepository.UpdateEmployer(Employer employer, int id)
        {
            throw new NotImplementedException();
        }

        Task<Employer> IEmployerRepository.FindEmployer(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Employer>> IEmployerRepository.FindEmployers()
        {
            throw new NotImplementedException();
        }

    }
}
