
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
using Microsoft.EntityFrameworkCore;
using Refit;

namespace FirstApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // global error handler
            app.UseMiddleware<GlobalExceptionHandler>();

            app.MapControllers();

            app.Run();
        }
    }
}
