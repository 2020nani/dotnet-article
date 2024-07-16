
using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;

namespace FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer
{
    public class ConsultEmployerService : IConsultEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public ConsultEmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        ConsultEmployerOutput IConsultEmployerService.FindEmployerById(int id)
        {
            ConsultEmployerOutput output = new ConsultEmployerOutput();
            Employer employer = _employerRepository.FindEmployer(id).Result;
            if (employer == null)
            {
                throw new Exception($"Usuario com id: {id} nao encontrado");
            };
            return output.convert(employer);
        }

        List<ConsultEmployerOutput> IConsultEmployerService.FindEmployers()
        {
            ConsultEmployerOutput output = new ConsultEmployerOutput();
            return _employerRepository.FindEmployers().Result
                .ConvertAll(
                new Converter<Employer, ConsultEmployerOutput>(obj => output.convert(obj))
                );
        }
    }
}
