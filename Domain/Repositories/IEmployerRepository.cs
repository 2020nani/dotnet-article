using FirstApi.Domain.Entities;

namespace FirstApi.Domain.Repositories
{
    public interface IEmployerRepository
    {
        Task<List<Employer>> FindEmployers();
        Task<Employer> FindEmployer(int id);
        Employer Register(Employer employer);
        Task<Employer> UpdateEmployer(Employer employer, int id);
        Task<string> DeleteEmployer(int id);
    }
}
