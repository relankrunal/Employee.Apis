namespace Employee.Infrastructure.Interface
{
     public interface IDbContextFactory
    {
         DbContext? CreateDbContext(DbContextName contextType);
    }
}