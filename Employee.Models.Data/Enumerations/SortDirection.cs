using System;
using System.Runtime.Serialization;

namespace Employee.Models.Data.Enumerations
{
    public enum SortDirection
    {
        [EnumMember(Value = "Ascending")]
        Ascending,

        [EnumMember(Value = "Descending")]
        Descending
    }
}

