using FirstApi.Application.UseCases.CasesEmployer.DeleteEmployer;
using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Application.UseCases.CasesUser.DeleteUser
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<DeleteUserService> _logger;

        public DeleteUserService (IUserRepository repository, ILogger<DeleteUserService> logger)
        {
            _repository = repository;
            _logger = logger;
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
                _logger.LogError(ex.Message);
                return $"Error by delete User with id {id}";
            }
        }
    }
}
