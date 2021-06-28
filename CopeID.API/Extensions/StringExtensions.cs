namespace CopeID.API.Extensions
{
    public static class StringExtensions
    {
        public static string[] ToPaselCase(this string[] strArr)
        {
            string[] arr = new string[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                arr[i] = strArr[i][0].ToString().ToUpper() + strArr[i].Substring(1);
            }

            return arr;
        }
    }
}
