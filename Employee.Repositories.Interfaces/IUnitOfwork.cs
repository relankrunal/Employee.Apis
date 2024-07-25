
using Employee.Infrastructure.Interface;
using Employee.Models.Client.Enumerations;
using Microsoft.Data.SqlClient;

namespace Employee.Repositories.Interfaces
{
	public interface IUnitOfwork
	{
		void SaveChanges();

		IGenericRepository<T> GetRepository<T>(DbContextName dbContextName) where T : class;

		Task<int?> ExecuteStoreProcedure<I>(string query, SqlParameter[] sqlParameters);
	}
}

