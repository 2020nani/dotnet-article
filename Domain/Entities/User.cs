using FirstApi.Domain.ValueObjects;
using FirstApi.Infrastructure.Integration.ViaCep;

namespace FirstApi.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Endereco? Endereco { get; set; }

        public Endereco GetEndereco(ViaCepResponse response)
        {
            Endereco endereco = new Endereco();
            if(response is null)
            {
                return endereco;
            }
            endereco.Complemento = response.Complemento;
            endereco.Cep = response.Cep;
            endereco.Bairro = response.Bairro;
            endereco.Logradouro = response.Logradouro;
            endereco.Localidade = response.Localidade;
            endereco.Cep = response.Cep;
            endereco.Unidade = response.Unidade;
            endereco.Uf = response.Uf;
            return endereco;
        }
    }
}
