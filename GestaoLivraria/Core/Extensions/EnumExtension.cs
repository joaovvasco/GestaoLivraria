namespace GestaoLivraria.Core.Extensions
{
    public static class EnumExtension
    {
        public static bool HasEnum<T>(this string rawEnum) where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Any(value => value.ToString() == rawEnum);
        }
    }
}
