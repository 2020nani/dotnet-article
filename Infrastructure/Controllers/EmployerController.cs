using FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer;
using FirstApi.Application.UseCases.CasesEmployer.DeleteEmployer;
using FirstApi.Application.UseCases.CasesEmployer.Register;
using FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Infrastructure.Controllers
{
    [Authorize(Roles = "ADMIN,USERCOMMON")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController
    {
        private readonly IRegisterEmployerService _registerService;
        private readonly IUpdateEmployerService _updateService;
        private readonly IConsultEmployerService _consultService;
        private readonly IDeleteEmployerService _deleteService;

        public EmployerController(
            IRegisterEmployerService service,
            IUpdateEmployerService updateService,
            IConsultEmployerService consultService,
            IDeleteEmployerService deleteService)
        {
            _registerService = service;
            _updateService = updateService;
            _consultService = consultService;
            _deleteService = deleteService;
        }

        [HttpPost]
        public RegisterEmployerOutput Post([FromBody] RegisterEmployerInput input)
        {
            return _registerService.Execute(input);
        }

        [HttpPut]
        public UpdateEmployerOutput Put([FromBody] UpdateEmployerInput input)
        {
            return _updateService.Execute(input);
        }

        [HttpGet("{id}")]
        public ConsultEmployerOutput findEmployer(int id)
        {
            return _consultService.FindEmployerById(id);
        }

        [HttpGet]
        public List<ConsultEmployerOutput> findEmployers()
        {
            return _consultService.FindEmployers();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _deleteService.DeleteEmployer(id);
        }
    }
}
