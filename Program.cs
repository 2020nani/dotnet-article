
using FirstApi.Application.UseCases.CasesEmployer;
using FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer;
using FirstApi.Application.UseCases.CasesEmployer.DeleteEmployer;
using FirstApi.Application.UseCases.CasesEmployer.Register;
using FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.Data;
using FirstApi.Infrastructure.Handler;
using FirstApi.Infrastructure.Repositories;
using ICSharpCode.SharpZipLib.Tar;
using Microsoft.EntityFrameworkCore;

namespace FirstApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SystemDbContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.
            builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
            builder.Services.AddScoped<IUseCasesEmployerFacade<RegisterEmployerOutput, RegisterEmployerInput>, RegisterEmployerService>();
            builder.Services.AddScoped<IUpdateEmployerService, UpdateEmployerService>();
            builder.Services.AddScoped<IConsultEmployerService, ConsultEmployerService>();
            builder.Services.AddScoped<IDeleteEmployerService, DeleteEmployerService>();

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
