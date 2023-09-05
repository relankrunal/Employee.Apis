using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Employee.Data.EF
{
    public static class QueryableExtensions
    {
        private const string Ascending = "ASC";

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property, string direction)
        {
            return direction == Ascending ? source.OrderBy(property) : source.OrderByDescending(property);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "OrderByDescending");
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property, string direction)
        {
            return direction == Ascending ? source.ThenBy(property) : source.ThenByDescending(property);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "ThenBy");
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "ThenByDescending");
        }

        public static IQueryable<T> IncludePropertyListCsv<T>(this IQueryable<T> query, string includeProperties) where T : class
        {
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "x");

            Expression expression = parameter;

            foreach (var item in props)
            {
                PropertyInfo propertyInfo = type.GetProperty(item, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                expression = Expression.Property(expression, propertyInfo);
                type = propertyInfo.PropertyType;
            }

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);

            LambdaExpression lambda = Expression.Lambda(delegateType, expression, parameter);

            object result = typeof(Queryable).GetMethods().Single(
                m => m.Name == methodName
                     && m.IsGenericMethodDefinition
                     && m.GetGenericArguments().Length == 2
                     && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T),type)
                .Invoke(null, new object[] { source, lambda});

            return (IOrderedQueryable<T>)result;
        }
    }
}

