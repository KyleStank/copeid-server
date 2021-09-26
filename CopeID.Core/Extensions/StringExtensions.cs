using System;

namespace CopeID.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string str) => str[0].ToString().ToUpper() + str.Substring(1);

        public static string ToPascalCase(this string str, char seperator) => string.Join(seperator, str.Split(seperator).ToPascalCase());

        public static string[] ToPascalCase(this string[] strArr)
        {
            string[] result = new string[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] == null) continue;
                result[i] = strArr[i].ToPascalCase();
            }

            return Array.FindAll(result, s => s != null) ?? Array.Empty<string>();
        }

        public static string[] ToPascalCase(this string[] strArr, char seperator)
        {
            string[] result = new string[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] == null) continue;
                result[i] = strArr[i].ToPascalCase(seperator);
            }

            return Array.FindAll(result, s => s != null) ?? Array.Empty<string>();
        }
    }
}
