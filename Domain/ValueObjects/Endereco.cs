using FirstApi.Infrastructure.Integration.ViaCep;

namespace FirstApi.Domain.ValueObjects
{
    public class Endereco
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Unidade { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }

    }
}
