using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace Employee.Repositories.EF
{
    public class Parameters
    {
        public static SqlParameter[] Transform<T>(T input, string output)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (input is not null)
            {
                var properties = input.GetType().GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];

                    if (property.GetValue(input) != null)
                    {
                        parameters.Add(new SqlParameter("@" + property.Name, property.GetValue(input)));
                    }
                }
            }

            if (!string.IsNullOrEmpty(output))
            {
                var outputParamter = new SqlParameter("@"+ output,SqlDbType.Int);

                outputParamter.Direction = ParameterDirection.Output;

                parameters.Add(outputParamter);
            }

            return parameters.ToArray();
        }
    }
}

