using FirstApi.Domain.Entities;

namespace FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer
{
    public class UpdateEmployerOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? message { get; set; }

        public UpdateEmployerOutput convert(Employer actualEmployer)
        {
            Id = actualEmployer.Id;
            Name = actualEmployer.Nome;
            message = "Update has a success";
            return this;
        }
    }
}
