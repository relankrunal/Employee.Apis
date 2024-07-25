using Employee.Models.Client.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Interface
{
    public interface IDbContextFactory
    {
        DbContext? CreateDbContext(DbContextName contextType);
    }
}