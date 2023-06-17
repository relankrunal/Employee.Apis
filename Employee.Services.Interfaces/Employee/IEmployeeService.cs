using System;
using Employee.Models.Client.Dtos;

namespace Employee.Services.Interfaces.Employee
{
	public interface IEmployeeService : ISimpleServiceBase
	{
		Task<EmployeeResponse> Create(CreateEmployee employee);
	}
}

