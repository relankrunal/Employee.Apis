using System;
using Employee.Services.Interfaces;

namespace Employee.Services.Core
{
    public abstract class SimpleServiceBase : ISimpleServiceBase
    {
        public string ErrorMessage { get; set; }
    }
}

