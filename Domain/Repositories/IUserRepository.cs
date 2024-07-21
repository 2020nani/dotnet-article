using FirstApi.Domain.Entities;

namespace FirstApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> FindUsers();
        Task<User> FindUser(int id);
        Task<User> Register(User user);
        Task<User> UpdateUser(User user);
        void DeleteUser(User user);
    }
}
