using System;
using Employee.Data.EF;
using Employee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories.EF
{
    public class UnitOfWork : IUnitOfwork
    {
        private AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<int?> ExecuteStoreProcedure<I>(string procName, I input, string output = "", bool forJob = false)
        {
            var sqlParams = Parameters.Transform(input, output);
            var stringOfParameters = string.Join(separator: ",",
                values: sqlParams.Where(a => a.Direction != System.Data.ParameterDirection.Output).Select(s => s.ParameterName));

            if (!string.IsNullOrEmpty(output))
            {
                stringOfParameters += ", @" + output;
            }

            if (forJob)
                context.Database.SetCommandTimeout(0);

            var response = await context.Database.ExecuteSqlRawAsync(procName + " " + stringOfParameters, sqlParams);
            var outParameter = sqlParams.Where(a => a.Direction == System.Data.ParameterDirection.Output).FirstOrDefault();
            if (outParameter != null)
            {
                return (int)outParameter.Value;
            }

            return null;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

