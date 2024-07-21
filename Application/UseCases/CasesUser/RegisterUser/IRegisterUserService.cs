using FirstApi.Domain.ValueObjects;
using FirstApi.Infrastructure.Integration.ViaCep;

namespace FirstApi.Application.UseCases.CasesUser.RegisterUser
{
    public interface IRegisterUserService
    {
        public RegisterUserOutput Execute(RegisterUserInput input, ViaCepResponse response);
    }
}
