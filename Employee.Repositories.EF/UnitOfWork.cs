using System;
using Employee.Data.EF;
using Employee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories.EF
{
    public class UnitOfWork : IUnitOfWork
{
    private readonly IDbContextFactory _dbContextFactory;

    private DbContext _context;

    public UnitOfWork(IDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public IGenericRepository<T> GetRepository<T>(DbContextName contextType) where T : class
    {
        _context ??= _dbContextFactory.CreateDbContext(contextType);

        return new GenericRepository<T>(_context);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task<int?> ExecuteStoredProcedure(string query, SqlParameter[] sqlParams)
    {
        var response = await _context.Database.ExecuteSqlRawAsync(query, sqlParams);
        var outParameter = sqlParams.Where(x => x.Direction == ParameterDirection.Output).FirstOrDefault();
        if (outParameter != null)
        {
            return (int)outParameter.Value;
        }
        return null;
    }
}
}

