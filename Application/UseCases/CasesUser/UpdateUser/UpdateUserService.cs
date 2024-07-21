using FirstApi.Domain.Repositories;
using FirstApi.Domain.Entities;
using FirstApi.Infrastructure.CustomException;
using FirstApi.Application.UseCases.PasswordHasher;

namespace FirstApi.Application.UseCases.CasesUser.UpdateUser
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserService(IUserRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        UpdateUserOutput IUpdateUserService.Execute(UpdateUserInput input)
        {
            UpdateUserOutput output = new UpdateUserOutput();
            User user = _repository.FindUser(input.Id).Result;
            if (user == null)
            {
                throw new AppNotFoundException($"Usuario com id: {input.Id} nao encontrado");
            }
            if (!_passwordHasher.Verify(user.Password, input.OldPassword))
            {
                throw new AppException("Password is not correct");
            }
                User newData = _repository.UpdateUser(input.Convert(user)).Result;
            return output.Convert(input.Convert(newData));

        }
    }
}
