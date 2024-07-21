using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Application.UseCases.CasesUser.DeleteUser
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IUserRepository _repository;

        public DeleteUserService (IUserRepository repository)
        {
            _repository = repository;
        }
        string IDeleteUserService.Execute(int id)
        {
            try
            {
                User user = _repository.FindUser(id).Result;
                _repository.DeleteUser(user);
                return "Deleted by success";
            }
            catch (Exception ex)
            {
                return $"Error by delete User with id {id}";
            }
        }
    }
}
