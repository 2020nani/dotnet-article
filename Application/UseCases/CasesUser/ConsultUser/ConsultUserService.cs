
using FirstApi.Domain.Repositories;
using FirstApi.Domain.Entities;
using FirstApi.Infrastructure.CustomException;
using FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer;
using FirstApi.Infrastructure.Repositories;

namespace FirstApi.Application.UseCases.CasesUser.ConsultUser
{
    public class ConsultUserService : IConsultUserService
    {
        private readonly IUserRepository _repository;
        public ConsultUserService(IUserRepository repository)
        {
            _repository = repository;
        }

        ConsultUserOutput IConsultUserService.FindUserById(int id)
        {
            ConsultUserOutput output = new ConsultUserOutput();
            User user = _repository.FindUser(id).Result;
            if (user == null)
            {
                throw new AppNotFoundException($"Usuario com id: {id} nao encontrado");
            }
            return output.Convert(user);
        }

        List<ConsultUserOutput> IConsultUserService.FindUsers()
        {
            ConsultUserOutput output = new ConsultUserOutput();
            return _repository.FindUsers()
                .Result
                .ConvertAll(
                new Converter<User, ConsultUserOutput>(obj => output.Convert(obj))
                );
        }
    }
}
