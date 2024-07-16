using FirstApi.Domain.Entities;

namespace FirstApi.Domain.Repositories
{
    public interface IEmployerRepository
    {
        Task<List<Employer>> FindEmployers();
        Task<Employer> FindEmployer(int id);
        Task<Employer> Register(Employer employer);
        Task<Employer> UpdateEmployer(Employer employer);
        void DeleteEmployer(Employer employer);
    }
}
