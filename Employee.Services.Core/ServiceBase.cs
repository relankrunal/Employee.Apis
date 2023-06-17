using System;
using System.Collections.Generic;
using Employee.Models.Client.Messages.Response;
using Employee.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Data;

namespace Employee.Services.Core
{
    public abstract class ServiceBase<T> : SimpleServiceBase where T : class
    {
        internal T _repository;

        public ServiceBase(T repository)
        {
            _repository = repository;
        }

        protected internal virtual async Task<PagingList<O>> ExecuteStoreProcedure<I, O>(string procName,
            I input, string output = "") where O : class
        {
            var unitOfWork = _repository as IUnitOfwork;
            var repository = unitOfWork.GetRepository<O>();
            var parameters = GetSqlParams(input, output);
            var result = await repository.ExecuteStoreProcedure(procName, parameters);
            
        }

        protected internal virtual async Task<int?> ExecuteStoreProcedure<P>(string procName, P input,string output="")
        {
            var unitOfWork = _repository as IUnitOfwork;
            var parameters = GetSqlParams(input, output);

            var stringOfParams =
                string.Join(
                    separator: ',',
                    value: (string?[])parameters
                           .Where(a => a.Direction != System.Data.ParameterDirection.Output)
                           .Select(q => q.ParameterName));

            if (!string.IsNullOrEmpty(output))
            {
                stringOfParams += ", @" + output;
            }

            return await unitOfWork.ExecuteStoreProcedure(procName + " " + stringOfParams, parameters);
        }

        private SqlParameter[] GetSqlParams<K>(K input, string output = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (input != null)
            {
                var properties = input.GetType().GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    parameters.Add(new SqlParameter($"@{output}", SqlDbType.Int));
                }
                if (!string.IsNullOrEmpty(output))
                {
                    var outputParam = new SqlParameter($"@{output}", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;
                    parameters.Add(outputParam);
                }
            }
            return parameters.ToArray();
        }
    }
}

