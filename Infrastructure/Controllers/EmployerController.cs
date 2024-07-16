using FirstApi.Application.UseCases.CasesEmployer;
using FirstApi.Application.UseCases.CasesEmployer.Register;
using FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer;
using FirstApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController
    {
        private  IRegisterEmployerService _service;
        private IUpdateEmployerService _updateService;

        public EmployerController(
            IRegisterEmployerService service, 
            IUpdateEmployerService updateService)
        {
            _service = service;
            _updateService = updateService;
        }

        [HttpPost]
        public RegisterEmployerOutput Post([FromBody] RegisterEmployerInput input)
        {
            return _service.Execute(input);
        }

        [HttpPut]
        public UpdateEmployerOutput Put([FromBody] UpdateEmployerInput input)
        {
            return _updateService.Execute(input);
        }
    }
}
