namespace WebMagic
{
    public static class StringExtensions
    {
        public static string AddLeadingDot(this string value)
        {
            return "." + value.RemoveLeadingDot();
        }

        public static string RemoveLeadingDot(this string value)
        {
            return value.TrimStart('.');
        }
    }
}