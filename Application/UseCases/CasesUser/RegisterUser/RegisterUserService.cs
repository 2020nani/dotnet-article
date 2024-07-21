using FirstApi.Application.UseCases.PasswordHasher;
using FirstApi.Domain.Repositories;
using FirstApi.Domain.ValueObjects;
using FirstApi.Infrastructure.Integration.ViaCep;

namespace FirstApi.Application.UseCases.CasesUser.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _repository;

        public RegisterUserService(IPasswordHasher passwordHasher, IUserRepository repository)
        {
            _passwordHasher = passwordHasher;
            _repository = repository;
        }

        RegisterUserOutput IRegisterUserService.Execute(RegisterUserInput input, ViaCepResponse viaCepResponse)
        {
            RegisterUserOutput output = new RegisterUserOutput();

            return output.Convert(_repository.Register(input.Convert(_passwordHasher, viaCepResponse)).Result);
        }
    }
}
