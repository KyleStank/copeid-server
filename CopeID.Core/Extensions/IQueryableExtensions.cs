using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CopeID.Core.Extensions
{
    // Source: https://stackoverflow.com/questions/34899933/sorting-using-property-name-as-string
    public static class IQueryableExtensions
    {
        private static readonly Type _queryableType = typeof(Queryable);

        private static readonly MethodInfo[] _queryableMethods = _queryableType.GetMethods().Where(x => x.GetParameters().Length == 2).ToArray();
        private static readonly MethodInfo _orderByMethod = _queryableMethods.First(x => x.Name == "OrderBy");
        private static readonly MethodInfo _orderByDescendingMethod = _queryableMethods.First(x => x.Name == "OrderByDescending");
        private static readonly MethodInfo _thenByMethod = _queryableMethods.First(x => x.Name == "ThenBy");
        private static readonly MethodInfo _thenByDescendingMethod = _queryableMethods.First(x => x.Name == "ThenByDescending");

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            return CreateOrderedQuery(query, _orderByMethod, propertyName);
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName)
        {
            return CreateOrderedQuery(query, _orderByDescendingMethod, propertyName);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IQueryable<T> query, string propertyName)
        {
            return CreateOrderedQuery(query, _thenByMethod, propertyName);
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IQueryable<T> query, string propertyName)
        {
            return CreateOrderedQuery(query, _thenByDescendingMethod, propertyName);
        }

        private static IOrderedQueryable<T> CreateOrderedQuery<T>(IQueryable<T> query, MethodInfo orderMethod, string propertyName)
        {
            // Create Lambda expression,
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            Expression property = Expression.Property(parameter, propertyName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            // Convert provided method into method that uses Lambda expression above.
            MethodInfo genericOrderMethod = orderMethod.MakeGenericMethod(typeof(T), property.Type);
            object result = genericOrderMethod.Invoke(null, new object[] { query, lambda });
            return (IOrderedQueryable<T>)result;
        }
    }
}
