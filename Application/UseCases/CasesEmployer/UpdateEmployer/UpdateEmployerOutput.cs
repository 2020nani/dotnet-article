using FirstApi.Domain.Entities;

namespace FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer
{
    public class UpdateEmployerOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Message { get; set; }

        public UpdateEmployerOutput Convert(Employer actualEmployer)
        {
            Id = actualEmployer.Id;
            Name = actualEmployer.Nome;
            Message = "Update has a success";
            return this;
        }
    }
}
