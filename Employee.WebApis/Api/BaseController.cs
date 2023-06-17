using System;
using Microsoft.AspNetCore.Mvc;

namespace Employee.WebApis.Api
{
    public abstract class BaseController<T> : Controller where T : class
    {
        public const string _defaultServerErrorMessage = "Server Error";

        internal readonly T _service;

        public BaseController(T service)
        {
            _service = service;
        }
    }
}

