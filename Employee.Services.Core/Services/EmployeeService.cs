using System;
using Employee.Models.Client.Dtos;
using Employee.Repositories.Interfaces;
using Employee.Services.Interfaces.Employees;

namespace Employee.Services.Core.Services
{
    public class EmployeeService : ServiceBase<IUnitOfwork>, IEmployeeService
    {
        public EmployeeService(IUnitOfwork repository) : base(repository)
        {
        }

        public Task<EmployeeResponse> Create(CreateEmployee employee)
        {
            throw new NotImplementedException();
        }
    }
}

