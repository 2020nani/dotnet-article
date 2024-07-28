
using FirstApi.Application.UseCases.CasesAuth.Login;
using FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer;
using FirstApi.Application.UseCases.CasesEmployer.DeleteEmployer;
using FirstApi.Application.UseCases.CasesEmployer.Register;
using FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer;
using FirstApi.Application.UseCases.CasesUser.ConsultUser;
using FirstApi.Application.UseCases.CasesUser.DeleteUser;
using FirstApi.Application.UseCases.CasesUser.RegisterUser;
using FirstApi.Application.UseCases.CasesUser.UpdateUser;
using FirstApi.Application.UseCases.PasswordHasher;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.Data;
using FirstApi.Infrastructure.Handler;
using FirstApi.Infrastructure.Integration.ViaCep;
using FirstApi.Infrastructure.Integration.ViaCep.Refit;
using FirstApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Refit;
using System.Text;

namespace FirstApi
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            string secretKey = "e0606215-c2e4-46fe-8d73-a77e1fa4f45a";
            var builder = WebApplication.CreateBuilder(args);
            // Configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            // Configure data base access
            builder.Services.AddDbContext<SystemDbContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add repositories to the container.
            builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            // Add services to the container.
            // employer
            builder.Services.AddScoped<IRegisterEmployerService, RegisterEmployerService>();
            builder.Services.AddScoped<IUpdateEmployerService, UpdateEmployerService>();
            builder.Services.AddScoped<IConsultEmployerService, ConsultEmployerService>();
            builder.Services.AddScoped<IDeleteEmployerService, DeleteEmployerService>();
            // user
            builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
            builder.Services.AddScoped<IUpdateUserService, UpdateUserService>();
            builder.Services.AddScoped<IConsultUserService, ConsultUserService>();
            builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<ILoginService,LoginService>();
            // client viacep
            builder.Services.AddScoped<IViaCepIntegrationService, ViaCepIntegrationService>();
            // Add client refit
            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            }
            );
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
                    Title = "ApiFirst", Version = "v1"
                });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "Enter with your Jwt Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                sw.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
                sw.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new string[] { } }
                });
            });

            // Config authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience= true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "emprise",
                    ValidAudience = "firstApi",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            // global error handler
            app.UseMiddleware<GlobalExceptionHandler>();

            app.MapControllers();

            app.Run();
        }
    }
}
