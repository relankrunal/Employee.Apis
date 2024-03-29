using System;
using Employee.Models.Client.Dtos;

namespace Employee.Services.Interfaces.Employees
{
	public interface IEmployeeService : ISimpleServiceBase
	{
		Task<EmployeeResponse> Create(CreateEmployee employee);
	}
}

