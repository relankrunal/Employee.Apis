using Employee.Models.Data.Messages.Response;
using Employee.Repositories.Interfaces;

namespace Employee.Services.Core
{
    public abstract class ServiceBase<T> : SimpleServiceBase where T : class
    {
        internal T _repository;

        public ServiceBase(T repository)
        {
            _repository = repository;
        }

        protected internal virtual async Task<PagingList<O>?> ExecuteStoreProcedure<I, O>(string procName, I input, string output = "") where O : class
        {
            var unitOfWork = _repository as IUnitOfwork;

            var repository = unitOfWork?.GetRepository<O>();

            if (repository != null)
            {
                var result = await repository.ExecuteStoreProcedure(procName, input, output);
                return result;
            }
            return default;
        }

        protected internal virtual async Task<int?> ExecuteStoreProcedure<I>(string procName, I input, string output = "", bool forJob = false)
        {
            var unitOfWork = _repository as IUnitOfwork;

            if (unitOfWork != null)
            {
                var result = await unitOfWork.ExecuteStoreProcedure(procName, input, output, forJob);
                return result;
            }

            return default;
        }
    }
}

