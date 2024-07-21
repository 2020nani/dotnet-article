

using FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer;
using FirstApi.Application.UseCases.CasesEmployer.Register;
using FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer;
using FirstApi.Application.UseCases.CasesUser.ConsultUser;
using FirstApi.Application.UseCases.CasesUser.DeleteUser;
using FirstApi.Application.UseCases.CasesUser.RegisterUser;
using FirstApi.Application.UseCases.CasesUser.UpdateUser;
using FirstApi.Infrastructure.Integration.ViaCep;
using FirstApi.Infrastructure.Integration.ViaCep.Refit;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IConsultUserService _consultUserService;
        private readonly IViaCepIntegrationService _viaCepIntegrationService; 

        public UserController(
            IRegisterUserService registerUserService, 
            IUpdateUserService updateUserService, 
            IDeleteUserService deleteUserService, 
            IConsultUserService consultUserService,
            IViaCepIntegrationService viaCepIntegrationService)
        {
            _registerUserService = registerUserService;
            _updateUserService = updateUserService;
            _deleteUserService = deleteUserService;
            _consultUserService = consultUserService;
            _viaCepIntegrationService = viaCepIntegrationService;
        }

        [HttpPost]
        public  RegisterUserOutput Post([FromBody] RegisterUserInput input)
        {
            ViaCepResponse response;
            if(input._Cep is null)
            {
                response = new ViaCepResponse();
            } else
            {
                response = _viaCepIntegrationService.FindEnderecoByCep(input._Cep).Result;
            }

            return _registerUserService.Execute(input, response);
        }

        /*[HttpPut]
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
        }*/
    }
}
