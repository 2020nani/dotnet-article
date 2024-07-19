using FirstApi.Application.UseCases.CasesEmployer.Register;

namespace FirstApi.Application.UseCases.CasesEmployer
{
    public interface IUseCasesEmployerFacade<TOutput, TInput>
    {
        public TOutput Execute(TInput Input);
    }
}
