using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly SystemDbContext _Dbcontext;

        public EmployerRepository(SystemDbContext context)
        {
            _Dbcontext = context;
        }

        async Task<Employer> IEmployerRepository.Register(Employer employer)
        {
            await _Dbcontext.Employers.AddAsync(employer);
            _Dbcontext.SaveChanges();
            return employer;
        }

        async void IEmployerRepository.DeleteEmployer(Employer employer)
        {
            _Dbcontext.Employers.Remove(employer);
            await _Dbcontext.SaveChangesAsync();
        }

        async Task<Employer> IEmployerRepository.UpdateEmployer(Employer employer)
        {
            _Dbcontext.Employers.Update(employer);
            await _Dbcontext.SaveChangesAsync();
            return employer;
        }

        async Task<Employer> IEmployerRepository.FindEmployer(int id)
        {
            return await _Dbcontext.Employers.FirstOrDefaultAsync(u => u.Id == id);
        }

        async Task<List<Employer>> IEmployerRepository.FindEmployers()
        {
            return await _Dbcontext.Employers.ToListAsync();
        }

    }
}
