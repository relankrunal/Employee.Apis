using System;
using System.Runtime.Serialization;

namespace Employee.Models.Client.Enumerations
{
    public enum SortDirection
    {
        [EnumMember(Value = "Ascending")]
        Ascending,

        [EnumMember(Value = "Descending")]
        Descending,
    }
}

