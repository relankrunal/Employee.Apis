using System;
using Employee.Infrastructure;
using Employee.Infrastructure.Interface;
using Employee.Models.Client.Enumerations;
using Employee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories.EF
{
	public class UnitOfWork : IUnitOfwork
    {
        private readonly IDbContextFactory _dbContextFactory;

        private DbContext _context;

		public UnitOfWork(IDbContextFactory dbContextFactory)
		{
            _dbContextFactory = dbContextFactory;
		}

        //public async Task<int?> ExecuteStoreProcedure<I>(string query, I input, string outPut = "", bool forJob = false)
        //{
        //    var respone = await _context.Database.ExecuteSqlRawAsync(query,SqlParameter) 
        //}

        public IGenericRepository<T> GetRepository<T>(DbContextName dbContextName) where T : class
        {
            _context ??= _dbContextFactory.CreateDbContext(dbContextName);

            return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
              
    }
}

