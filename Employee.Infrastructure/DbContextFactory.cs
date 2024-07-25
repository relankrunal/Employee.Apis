using Employee.Data.EF;
using Employee.Infrastructure.Interface;
using Employee.Models.Client.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public DbContext? CreateDbContext(DbContextName contextType)
        {
            switch (contextType)
            {
                case DbContextName.AppDbContext:
                    return _serviceProvider.GetRequiredService<AppDbContext>();
                default:
                    return default;
            }

        }
    }
}