namespace FirstApi.Application.UseCases.CasesUser.ConsultUser
{
    public interface IConsultUserService
    {
        public ConsultUserOutput FindUserById(int id);
        public List<ConsultUserOutput> FindUsers();
    }
}
