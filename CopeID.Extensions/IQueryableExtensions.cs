using System;
using System.Linq;
using System.Linq.Expressions;

namespace CopeID.Extensions
{
    // Source: https://stackoverflow.com/questions/1689199/c-sharp-code-to-order-by-a-property-using-the-property-name-as-a-string
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            return query.OrderBy(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName)
        {
            return query.OrderByDescending(ToLambda<T>(propertyName));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            MemberExpression property = Expression.Property(parameter, propertyName);
            //UnaryExpression propAsObject = Expression.Convert(property, typeof(Guid));
            return Expression.Lambda<Func<T, object>>(property, parameter);
        }
    }
}
