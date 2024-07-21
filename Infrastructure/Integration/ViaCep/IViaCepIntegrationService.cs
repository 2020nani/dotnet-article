namespace FirstApi.Infrastructure.Integration.ViaCep
{
    public interface IViaCepIntegrationService
    {
        public Task<ViaCepResponse> FindEnderecoByCep(string cep);
    }
}
