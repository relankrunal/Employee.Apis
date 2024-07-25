namespace Employee.Repositories.Ef
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        protected IQueryable<T> GetEntitySet()
        {
            return _context.Set<T>();
        }

        protected PagingList<T> Search(Expression<Func<T, bool>> selector, ISearchCriteria criteria, string includeProperties = null)
        {
            var toReturn = new PagingList<T>();
            var queryBuilder = SearchQueryable(selector, includeProperties);

            if (!string.IsNullOrEmpty(criteria.SortFieldName))
            {
                //queryBuilder = queryBuilder.OrderBy(
                    //property: criteria.SortFieldName,
                    //direction: criteria.SortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }

            toReturn.TotalCount = queryBuilder.Count();

            //Skip can only be used with sorting
            if (criteria.PageSize != -1 && !string.IsNullOrEmpty(criteria.SortFieldName))
            {
                queryBuilder = queryBuilder
                    .Skip(criteria.PageSize * (criteria.PageNumber - 1))
                    .Take(criteria.PageSize);
            }

            toReturn.AddRange(queryBuilder);

            return toReturn;
        }

        protected IEnumerable<T> Search(Expression<Func<T, bool>> selector, string includeProperties = null)
        {
            return SearchQueryable(selector, includeProperties).ToList();
        }

        protected IQueryable<T> SearchQueryable(Expression<Func<T, bool>> selector, string includeProperties = null)
        {
            return GetEntitySet()
                       .Where(selector);
                       //.IncludePropertyListCsv(includeProperties);
        }

        protected T Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        protected T Read(Expression<Func<T, bool>> selector, string includeProperties = null)
        {
            return Search(selector, includeProperties).FirstOrDefault();
        }

        protected List<T> ReadAll(string includeProperties = null)
        {
            return GetEntitySet()
                 //.IncludePropertyListCsv(includeProperties)
                .ToList();
        }

        //internal long GetCount(Expression<Func<T, bool>> selector)
        //{
        //    return GetEntitySet().Where(selector).Count();
        //}

        protected T Update(Expression<Func<T, bool>> selector, T entity)
        {
            var existingEntity = _context.Set<T>().FirstOrDefault(selector);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        protected void Delete(Expression<Func<T, bool>> selector, string includeProperties = null)
        {
            var entities = GetEntitySet()
                            .Where(selector)
                            //.IncludePropertyListCsv(includeProperties)
                            .ToList();

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    _context.Set<T>().Remove(entity);
                }
                _context.SaveChanges();
            }
        }
    }
}
