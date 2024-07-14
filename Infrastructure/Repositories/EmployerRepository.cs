using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        Employer IEmployerRepository.AdicionarUsuario(Employer employer)
        {
            return employer;
        }

        Task<string> IEmployerRepository.DeletarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        Task<Employer> IEmployerRepository.EditarUsuario(Employer employer, int id)
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
