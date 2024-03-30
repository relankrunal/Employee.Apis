using System;
using AutoMapper;
using Employee.Models.Client.Dtos;
using Employee.Repositories.Interfaces;
using Employee.Services.Interfaces.Employees;
using Microsoft.Extensions.Logging;

namespace Employee.Services.Core.Services
{
    public class EmployeeService : ServiceBase<IUnitOfwork>, IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeeService(IUnitOfwork repository,
                               IMapper mapper,
                               ILogger<EmployeeService> logger) : base(repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        public async Task<EmployeeResponse> Create(CreateEmployee employee)
        {
            var toReturn = new EmployeeResponse();
            try
            {

            }
            catch (Exception ex)
            {

            }

            return toReturn;
        }
    }
}

