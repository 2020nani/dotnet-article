using FirstApi.Application.UseCases.PasswordHasher;
using FirstApi.Domain.Repositories;
using FirstApi.Domain.ValueObjects;
using FirstApi.Infrastructure.Integration.ViaCep;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FirstApi.Application.UseCases.CasesUser.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _repository;
        private readonly ILogger<RegisterUserService> _logger;

        public RegisterUserService(
            IPasswordHasher passwordHasher, 
            IUserRepository repository,
            ILogger<RegisterUserService> logger)
        {
            _passwordHasher = passwordHasher;
            _repository = repository;
            _logger = logger;
        }

        RegisterUserOutput IRegisterUserService.Execute(RegisterUserInput input, ViaCepResponse viaCepResponse)
        {
            RegisterUserOutput output = new RegisterUserOutput();
            _logger.LogInformation("Get Adress Data {object}", JsonSerializer.Serialize(viaCepResponse));
            _logger.LogInformation("Registering user {input}", JsonSerializer.Serialize(input));
            return output.Convert(_repository.Register(input.Convert(_passwordHasher, viaCepResponse)).Result);
        }
    }
}
