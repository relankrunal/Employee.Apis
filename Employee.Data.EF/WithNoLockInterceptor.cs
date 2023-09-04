using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Employee.Data.EF
{
    public class WithNoLockInterceptor: DbCommandInterceptor
    {
    }
}

