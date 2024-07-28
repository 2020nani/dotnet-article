using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemDbContext _Dbcontext;

        public UserRepository(SystemDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        async void IUserRepository.DeleteUser(User user)
        {
            _Dbcontext.Users.Remove(user);
            await _Dbcontext.SaveChangesAsync();
        }

        async Task<User> IUserRepository.FindUser(int id)
        {
            return await _Dbcontext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        async Task<List<User>> IUserRepository.FindUsers()
        {
            return await _Dbcontext.Users.ToListAsync();
        }

        async Task<User> IUserRepository.Register(User user)
        {
            await _Dbcontext.Users.AddAsync(user);
            _Dbcontext.SaveChanges();
            return user;
        }

        async Task<User> IUserRepository.UpdateUser(User user)
        {
            _Dbcontext.Users.Update(user);
            await _Dbcontext.SaveChangesAsync();
            return user;
        }

        async Task<User> IUserRepository.FindUserByEmail(string email)
        {
            return await _Dbcontext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
