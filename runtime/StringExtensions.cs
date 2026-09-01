using System.Text.RegularExpressions;

namespace GameDevFishy.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns true if this string is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Returns true if this string is null, empty, or whitespace only.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Truncates this string to maxLength, appending a suffix if it was cut.
        /// </summary>
        public static string Truncate(this string value, int maxLength, string suffix = "...")
        {
            if (value.IsNullOrEmpty() || value.Length <= maxLength)
                return value;

            return value.Substring(0, maxLength) + suffix;
        }

        /// <summary>
        /// Converts this string to Title Case.
        /// </summary>
        public static string ToTitleCase(this string value)
        {
            if (value.IsNullOrEmpty())
                return value;

            return System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Returns true if this string contains another, ignoring case.
        /// </summary>
        public static bool ContainsIgnoreCase(this string value, string other)
        {
            return value.IndexOf(other, System.StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Removes all whitespace characters from this string.
        /// </summary>
        public static string RemoveWhitespace(this string value)
        {
            return Regex.Replace(value, @"\s+", "");
        }

        /// <summary>
        /// Returns true if this string can be parsed as a number.
        /// </summary>
        public static bool IsNumeric(this string value)
        {
            return !value.IsNullOrEmpty() && float.TryParse(value, out _);
        }

        /// <summary>
        /// Returns this string with its characters in reverse order.
        /// </summary>
        public static string Reverse(this string value)
        {
            char[] chars = value.ToCharArray();
            System.Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// Converts this string from camelCase/PascalCase to snake_case.
        /// </summary>
        public static string ToSnakeCase(this string value)
        {
            return Regex.Replace(value, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        /// <summary>
        /// Converts this string to camelCase by lowercasing the first character.
        /// </summary>
        public static string ToCamelCase(this string value)
        {
            if (value.IsNullOrEmpty())
                return value;

            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// Returns true if this string equals another, ignoring case.
        /// </summary>
        public static bool EqualsIgnoreCase(this string value, string other)
        {
            return string.Equals(value, other, System.StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Converts this string from camelCase/snake_case to PascalCase.
        /// </summary>
        public static string ToPascalCase(this string value)
        {
            if (value.IsNullOrEmpty())
                return value;

            string camel = value.ToCamelCase();
            return char.ToUpperInvariant(camel[0]) + camel.Substring(1);
        }

        /// <summary>
        /// Returns a copy of this string with only the first character uppercased.
        /// </summary>
        public static string FirstCharToUpper(this string value)
        {
            if (value.IsNullOrEmpty())
                return value;

            return char.ToUpperInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// Wraps this string in a Unity rich text color tag.
        /// e.g. "Score".Colorize("#FF0000") or "Score".Colorize("red")
        /// </summary>
        public static string Colorize(this string value, string hexOrColorName)
        {
            return $"<color={hexOrColorName}>{value}</color>";
        }

        /// <summary>
        /// Returns true if this string is a plausibly valid email address.
        /// Basic format check only, not full RFC validation.
        /// </summary>
        public static bool IsEmail(this string value)
        {
            if (value.IsNullOrEmpty())
                return false;

            return Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
