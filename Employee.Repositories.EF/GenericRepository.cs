using System;
using System.Linq.Expressions;
using Employee.Models.Data.Enumerations;
using Employee.Models.Data.Messages.Response;
using Employee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories.EF
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
        internal AppDbContext context;
        internal DbSet<T> dbSet;

		public GenericRepository(AppDbContext context)
		{
            this.context = context;
            dbSet = context.Set<T>();
		}

        public Task<PagingList<T>> ExecuteStoreProcedure<I>(string procName, I input, string parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetQyery(Expression<Func<T, bool>> filter = null, bool IsInclude = false)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> InsertRage(List<T> entitiesToInsert)
        {
            throw new NotImplementedException();
        }

        public Task<PagingList<T>> Search(Expression<Func<T, bool>> flter = null, int? pageSize = null, int pageNumber = 1, SortDirection sortDirection = SortDirection.Ascending, string sortField = "", bool isInclude = false)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> UpdateRage(List<T> entitiesToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

