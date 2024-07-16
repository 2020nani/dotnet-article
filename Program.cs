
using FirstApi.Application.UseCases.CasesEmployer.Register;
using FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer;
using FirstApi.Domain.Repositories;
using FirstApi.Infrastructure.Data;
using FirstApi.Infrastructure.Repositories;
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
            builder.Services.AddScoped<IRegisterEmployerService, RegisterEmployerService>();
            builder.Services.AddScoped<IUpdateEmployerService, UpdateEmployerService>();
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


            app.MapControllers();

            app.Run();
        }
    }
}
