

using FirstApi.Application.UseCases.CasesUser.ConsultUser;
using FirstApi.Application.UseCases.CasesUser.DeleteUser;
using FirstApi.Application.UseCases.CasesUser.RegisterUser;
using FirstApi.Application.UseCases.CasesUser.UpdateUser;
using FirstApi.Infrastructure.CustomException;
using FirstApi.Infrastructure.Integration.ViaCep;
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
        private readonly ILogger<UserController> _logger;

        public UserController(
            IRegisterUserService registerUserService,
            IUpdateUserService updateUserService,
            IDeleteUserService deleteUserService,
            IConsultUserService consultUserService,
            IViaCepIntegrationService viaCepIntegrationService,
            ILogger<UserController> logger)
        {
            _registerUserService = registerUserService;
            _updateUserService = updateUserService;
            _deleteUserService = deleteUserService;
            _consultUserService = consultUserService;
            _viaCepIntegrationService = viaCepIntegrationService;
            _logger = logger;
        }

        [HttpPost]
        public  RegisterUserOutput Post([FromBody] RegisterUserInput input)
        {
            ViaCepResponse response;
            if(input.Cep is null)
            {
                response = new ViaCepResponse();
            } else
            {
                try
                {
                    response = _viaCepIntegrationService.FindEnderecoByCep(input.Cep).Result;
                }
                catch (Exception ex) {
                    _logger.LogError(ex.Message);
                    throw new AppException("Error on integration with extern api");
                }
                
            }

            return _registerUserService.Execute(input, response);
        }

        [HttpPut]
        public UpdateUserOutput Put([FromBody] UpdateUserInput input)
        {
            return _updateUserService.Execute(input);
        }

        [HttpGet("{id}")]
        public ConsultUserOutput FindUser(int id)
        {
            return _consultUserService.FindUserById(id);
        }

        [HttpGet]
        public List<ConsultUserOutput> FindUsers()
        {
            return _consultUserService.FindUsers();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _logger.LogInformation($"Deleting user with id {id}");
            return _deleteUserService.Execute(id);
        }
    }
}
