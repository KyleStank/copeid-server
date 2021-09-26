using System;
using System.Linq;
using System.Linq.Expressions;

namespace CopeID.Core.Extensions
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderByProperty<T>(this IQueryable<T> query, string propertyName, char seperator = '.') =>
            Queryable.OrderBy(query, CreatedNestedLambda<T>(propertyName, seperator));

        public static IOrderedQueryable<T> OrderByPropertyDescending<T>(this IQueryable<T> query, string propertyName, char seperator = '.') =>
            Queryable.OrderByDescending(query, CreatedNestedLambda<T>(propertyName, seperator));

        public static IOrderedQueryable<T> ThenByProperty<T>(this IQueryable<T> query, string propertyName, char seperator = '.') =>
            Queryable.ThenBy((IOrderedQueryable<T>)query, CreatedNestedLambda<T>(propertyName, seperator));

        public static IOrderedQueryable<T> ThenByPropertyDescending<T>(this IQueryable<T> query, string propertyName, char seperator = '.') =>
            Queryable.ThenByDescending((IOrderedQueryable<T>)query, CreatedNestedLambda<T>(propertyName, seperator));

        // Source: https://stackoverflow.com/questions/34899933/sorting-using-property-name-as-string
        // Source: https://stackoverflow.com/questions/29084894/how-to-use-an-expressionfunc-to-set-a-nested-property
        private static Expression<Func<T, object>> CreatedNestedLambda<T>(string propertyName, char seperator)
        {
            // Create Lambda expression (i.e. "x").
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));

            // Create nested expression property (i.e. "x.Property.Nested...").
            Expression property = propertyName.Split(seperator).Aggregate<string, Expression>(parameterExpression, (c, m) => Expression.Property(c, m));

            // Create Lambda body (i.e. "x => x.Property.Nested...").
            Expression<Func<T, object>> lambda = Expression.Lambda<Func<T, object>>(
                Expression.Convert(property, typeof(object)), parameterExpression
            );
            return lambda;
        }
    }
}
