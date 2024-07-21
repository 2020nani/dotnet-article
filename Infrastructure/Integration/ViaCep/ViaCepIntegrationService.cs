
using FirstApi.Infrastructure.CustomException;
using FirstApi.Infrastructure.Integration.ViaCep.Refit;

namespace FirstApi.Infrastructure.Integration.ViaCep
{
    public class ViaCepIntegrationService : IViaCepIntegrationService
    {
        private readonly IViaCepIntegrationRefit _refit;

        public ViaCepIntegrationService(IViaCepIntegrationRefit refit)
        {
            _refit = refit;
        }

        async Task<ViaCepResponse> IViaCepIntegrationService.FindEnderecoByCep(string cep)
        {
            var responseData = await _refit.FindEnderecoByCep(cep);
            if(responseData is null || !responseData.IsSuccessStatusCode)
            {
                throw new AppException("Error on integration with extern api");
            }

            return responseData.Content;
        }
    }
}
