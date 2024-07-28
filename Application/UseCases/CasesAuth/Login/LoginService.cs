using FirstApi.Application.UseCases.PasswordHasher;
using FirstApi.Domain.Entities;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.CustomException;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstApi.Application.UseCases.CasesAuth.Login
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public LoginService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        LoginOutput ILoginService.Execute(LoginInput input)
        {
            User user = _userRepository.FindUserByEmail(input.Email).Result;
            if (user == null || user.Password == null || user.Email == null)
            {
                throw new AppNotFoundException("Credenciais Invalidas teste");
            }

            if (_passwordHasher.Verify(user.Password, input.Password))
            {
                return new LoginOutput().Convert(user, this.generateJwtToken());
            }

            throw new BadHttpRequestException("Credenciais Invalidas");

        }

        private string generateJwtToken()
        {
            string secretKey = "e0606215-c2e4-46fe-8d73-a77e1fa4f45a";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var claims = new[]
            {
                new Claim("login","admin"),
                new Claim("name", "System Administrator")
            };

            var token = new JwtSecurityToken(
                issuer: "emprise",
                audience: "firstApi",
                claims: claims,
                expires: new DateTime().AddHours(2),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
