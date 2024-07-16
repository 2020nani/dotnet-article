using FirstApi.Application.UseCases.CasesEmployer;
using FirstApi.Application.UseCases.CasesEmployer.Register;
using FirstApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController
    {
        private  IRegisterEmployerService _service;

        public EmployerController(IRegisterEmployerService service)
        {
            _service = service;
        }

        [HttpPost]
        public Employer Post([FromBody] RegisterEmployerInput input)
        {
            return _service.Execute(input);
        }
    }
}
