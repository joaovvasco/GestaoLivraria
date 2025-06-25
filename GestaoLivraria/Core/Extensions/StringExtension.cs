namespace GestaoLivraria.Core.Extensions
{
    public static class StringExtension
    {
        public static bool IsBlank(this string target) 
        {
            return target == null || target.Trim().Length == 0;
        }
    }
}
