using FirstApi.Domain.Entities;

namespace FirstApi.Domain.Repositories
{
    public interface IEmployerRepository
    {
        Task<List<Employer>> FindEmployers();
        Task<Employer> FindEmployer(int id);
        Employer AdicionarUsuario(Employer employer);
        Task<Employer> EditarUsuario(Employer employer, int id);
        Task<string> DeletarUsuario(int id);
    }
}
