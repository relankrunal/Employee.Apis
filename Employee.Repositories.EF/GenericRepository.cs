using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Employee.Data.EF;
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

        public async Task<PagingList<T>> ExecuteStoreProcedure<I>(string procName, I input, string output)
        {
            var toRetun = new PagingList<T>();
            var parameters = Parameters.Transform(input, output);
            var inputParams = parameters.Where(a => a.Direction != System.Data.ParameterDirection.Output)
                                        .Select(o => o.ParameterName).ToList();
            var stringOfParameters = string.Empty;
            var sqlString = new StringBuilder();
            foreach (var parameter in inputParams)
            {
                sqlString.Append($"{parameter} = {parameter}");
            }

            stringOfParameters = sqlString.ToString();

            if (!string.IsNullOrEmpty(output))
            {
                stringOfParameters += $" @{output}";
            }
            else
            {
                stringOfParameters = stringOfParameters.Remove(stringOfParameters.LastIndexOf(','));
            }

            var query = await dbSet.FromSqlRaw($"exec {procName} {stringOfParameters}", parameters.ToArray()).ToListAsync();
            toRetun.AddRange(query);

            if (!string.IsNullOrEmpty(output))
            {

                toRetun.TotalCount = (int)parameters[parameters.Length - 1].Value;
            }

            return toRetun;
        }

        public virtual Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var results = query.ToList();

            return Task.FromResult<IEnumerable<T>>(results);
        }

        public Task<T> GetById(object id)
        {
            var item = dbSet.Find(id);
            return Task.FromResult(item);
        }

        public IQueryable<T> GetQyery(Expression<Func<T, bool>> filter = null, bool IsInclude = false)
        {
            IQueryable<T> query = dbSet;

            if (IsInclude)
            {
                var navigationProperties = context.Model.FindEntityType(typeof(T)).GetNavigations();

                foreach (var item in navigationProperties)
                {
                    query = query.Include(item.Name);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }

        public Task<T> Insert(T entity)
        {
            return Task.FromResult(dbSet.Add(entity).Entity);
        }

        public Task<List<T>> InsertRage(List<T> entitiesToInsert)
        {
            dbSet.AddRange(entitiesToInsert);

            return Task.FromResult(entitiesToInsert);
        }

        public async Task<PagingList<T>> Search(Expression<Func<T, bool>> filter = null, int? pageSize = null, int pageNumber = 1,
            SortDirection sortDirection = SortDirection.Ascending, string sortField = "", bool isInclude = false)
        {
            var toRetun = new PagingList<T>();

            IQueryable<T> query = dbSet;

            if (isInclude)
            {
                var navigationProperties = context.Model.FindEntityType(typeof(T)).GetNavigations();

                foreach (var item in navigationProperties)
                {
                    query = query.Include(item.Name);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(sortField))
            {
                if (sortDirection == SortDirection.Ascending)
                {
                    query = query.OrderBy(property: sortField);
                }

                if (sortDirection == SortDirection.Descending)
                {
                    query = query.OrderByDescending(property: sortField);
                }
            }

            toRetun.TotalCount = query.Count();

            if (pageSize != null)
            {
                query = query.Skip((pageNumber - 1) * pageSize ?? 0)
                             .Take(pageSize ?? 0);
            }
            var result = await query.ToListAsync();
            toRetun.AddRange(result);
            return toRetun;
        }

        public Task<T> Update(T entity)
        {
            return Task.FromResult(dbSet.Update(entity).Entity);
        }

        public Task<List<T>> UpdateRage(List<T> entitiesToUpdate)
        {
            dbSet.AddRange(entitiesToUpdate);

            return Task.FromResult(entitiesToUpdate);
        }
    }
}

