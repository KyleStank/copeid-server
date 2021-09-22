using System;

namespace CopeID.Core.Extensions
{
    public static class StringExtensions
    {
        public static string[] ToPascalCase(this string[] strArr)
        {
            string[] result = new string[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] == null) continue;
                result[i] = strArr[i][0].ToString().ToUpper() + strArr[i].Substring(1);
            }

            return Array.FindAll(result, s => s != null) ?? Array.Empty<string>();
        }
    }
}
