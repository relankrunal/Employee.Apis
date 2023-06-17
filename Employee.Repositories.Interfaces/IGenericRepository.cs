using System;
using Employee.Models.Data.Response;
using Microsoft.Data.SqlClient;

namespace Employee.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<PagingList<T>> ExecuteStoreProcedure(string procName, SqlParameter[] parameters);
    }
}

