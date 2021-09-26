using System;
using System.Reflection;

namespace CopeID.Core.Extensions
{
    public static class TypeExtensions
    {
        public static PropertyInfo GetPropertyRecursive(this Type type, string propertyName, char seperator = '.')
        {
            string[] split = propertyName.Split(seperator);
            PropertyInfo result = type.GetProperty(split[0]);
            if (result != null && split.Length > 1)
            {
                result = GetPropertyRecursive(
                    result.PropertyType,
                    string.Join(seperator, new ArraySegment<string>(split, 1, split.Length - 1))
                );
            }
            return result;
        }
    }
}
