namespace Employee.Infrastructure.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>>? filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
          string includeProperties = "", bool ignoreQueryFilters = false);

        Task<PagingList<T>> Search(
            Expression<Func<T, bool>>? filter = null,
            int? pageSize = null, int pageNumber = 1, SortDirection sortDirection = SortDirection.Ascending,
            string sortField = "", bool IsInclude = false, bool ignoreQueryFilters = false);

        Task<PagingList<T>> Search(
           Expression<Func<T, bool>>? filter = null,
           int? pageSize = null,
           int pageNumber = 1,
           List<(string sortField, SortDirection sortDirection)>? sortFields = null,
           bool IsInclude = false,
           bool ignoreQueryFilters = false);

        Task<T?> GetByID(object id);

        Task<T?> GetByID(Expression<Func<T, bool>>? filter, bool includeNavigation = false, bool ignoreQueryFilters = false);

        Task<T> Insert(T entity);

        Task<T> UpdateAsync (T entityToUpdate);

        void Update(T entityToUpdate);

        Task<List<T>> UpdateRange(List<T> entitiesToUpdate);

        Task<List<T>> AddRange(List<T> entitiesToUpdate);

        Task<PagingList<T>> ExecuteStoredProcedure<I>(string procedureName, I input, string output);

        Task<IEnumerable<T>> GetAsNoTracking(Expression<Func<T, bool>> predicate);

        IQueryable<T?> GetQuery(Expression<Func<T, bool>>? filter = null, bool includeNavigation = false, bool ignoreQueryFilters = false);
    }
}
