
using Employee.Infrastructure.Interface;
using Employee.Models.Client.Enumerations;

namespace Employee.Repositories.Interfaces
{
	public interface IUnitOfwork
	{
		void SaveChanges();

		IGenericRepository<T> GetRepository<T>(DbContextName dbContextName) where T : class;

		//Task<int?> ExecuteStoreProcedure<I>(string query, I input, string outPut= "", bool forJob = false);
	}
}

