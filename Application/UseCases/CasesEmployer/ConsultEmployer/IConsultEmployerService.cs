namespace FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer
{
    public interface IConsultEmployerService
    {
        public List<ConsultEmployerOutput> FindEmployers();
        public ConsultEmployerOutput FindEmployerById(int id);
    }
}
