using System;
using Microsoft.Data.SqlClient;

namespace Employee.Repositories.Interfaces
{
	public interface IUnitOfwork
	{
		void SaveChanges();

		IGenericRepository<T> GetRepository<T>() where T : class;

		Task<int?> ExecuteStoreProcedure(string query, SqlParameter[] parameters);
	}
}

