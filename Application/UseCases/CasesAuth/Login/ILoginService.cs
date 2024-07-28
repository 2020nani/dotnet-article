namespace FirstApi.Application.UseCases.CasesAuth.Login
{
    public interface ILoginService
    {
        public LoginOutput Execute(LoginInput input);
    }
}
