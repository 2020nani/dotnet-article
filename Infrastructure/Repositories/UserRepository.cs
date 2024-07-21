using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.Data;

namespace FirstApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemDbContext _Dbcontext;

        public UserRepository(SystemDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        void IUserRepository.DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.FindUser(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IUserRepository.FindUsers()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.Register(User user)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
