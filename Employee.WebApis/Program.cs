
using Employee.Data.EF;
using Employee.Infrastructure;
using Employee.Infrastructure.Interface;
using Employee.Repositories.EF;
using Employee.Repositories.Interfaces;
using Employee.Services.Core;
using Employee.Services.Core.Services;
using Employee.Services.Interfaces.Employees;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //DB Context
        builder.Configuration.AddJsonFile("appsettings.Development.json");
        //var connectionString = builder.Configuration.GetConnectionString("");
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            _ = options.UseNpgsql(connectionString: builder.Configuration.GetConnectionString("SqlServer"));
            options.AddInterceptors(new WithNoLockInterceptor());
        }, ServiceLifetime.Scoped);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<IDbContextFactory, DbContextFactory>();
        builder.Services.AddTransient<IUnitOfwork, UnitOfWork>();

        builder.Services.AddTransient<IEmployeeService, EmployeeService>();

        builder.Services.AddAutoMapper(typeof(AutoMapperMappingProfile));

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