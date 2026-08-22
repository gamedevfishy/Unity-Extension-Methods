using System.Text.RegularExpressions;

namespace GameDevFishy.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string Truncate(this string value, int maxLength, string suffix = "...")
        {
            if (value.IsNullOrEmpty() || value.Length <= maxLength)
                return value;

            return value.Substring(0, maxLength) + suffix;
        }

        public static string ToTitleCase(this string value)
        {
            if (value.IsNullOrEmpty())
                return value;

            return System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public static bool ContainsIgnoreCase(this string value, string other)
        {
            return value.IndexOf(other, System.StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static string RemoveWhitespace(this string value)
        {
            return Regex.Replace(value, @"\s+", "");
        }

        public static bool IsNumeric(this string value)
        {
            return !value.IsNullOrEmpty() && float.TryParse(value, out _);
        }

        public static string Reverse(this string value)
        {
            char[] chars = value.ToCharArray();
            System.Array.Reverse(chars);
            return new string(chars);
        }

        public static string ToSnakeCase(this string value)
        {
            return Regex.Replace(value, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        public static string ToCamelCase(this string value)
        {
            if (value.IsNullOrEmpty())
                return value;

            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }
}
