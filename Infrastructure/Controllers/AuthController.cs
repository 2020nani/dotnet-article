using FirstApi.Application.UseCases.CasesAuth.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController
    {
        private ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public LoginOutput Login(LoginInput login)
        {
            return _loginService.Execute(login);
        }

    }
}
