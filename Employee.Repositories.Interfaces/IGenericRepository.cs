using System;
using System.Linq.Expressions;
using Employee.Models.Data.Enumerations;
using Employee.Models.Data.Messages.Response;
using Microsoft.Data.SqlClient;

namespace Employee.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        Task<PagingList<T>> Search(
            Expression<Func<T, bool>>? flter = null,
            int? pageSize = null,
            int pageNumber = 1,
            SortDirection sortDirection = SortDirection.Ascending,
            string sortField = "",
            bool isInclude = false
            );

        Task<T> GetById(object id);

        Task<T> Insert(T entity);

        Task<T> Update(T entity);

        IQueryable<T> GetQyery(Expression<Func<T, bool>>? filter = null, bool IsInclude = false);

        Task<List<T>> InsertRage(List<T> entitiesToInsert);

        Task<List<T>> UpdateRage(List<T> entitiesToUpdate);

        Task<PagingList<T>> ExecuteStoreProcedure<I>(string procName, I input, string parameters);
    }
}

