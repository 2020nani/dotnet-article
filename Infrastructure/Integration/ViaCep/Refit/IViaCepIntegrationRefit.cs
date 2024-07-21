using Refit;

namespace FirstApi.Infrastructure.Integration.ViaCep.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json/")]
        public Task<ApiResponse<ViaCepResponse>> FindEnderecoByCep(string cep);
    }
}
