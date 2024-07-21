namespace FirstApi.Application.UseCases.CasesUser.UpdateUser
{
    public interface IUpdateUserService
    {
        public UpdateUserOutput Execute(UpdateUserInput input);
    }
}
