namespace GameDevFishy.ExtensionMethods
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Converts this value to 1 (true) or 0 (false).
        /// </summary>
        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        /// Converts this value to "Yes" or "No".
        /// </summary>
        public static string ToYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }

        /// <summary>
        /// Returns the negated value.
        /// </summary>
        public static bool Toggle(this bool value)
        {
            return !value;
        }

        /// <summary>
        /// Converts this value to 1 (true) or -1 (false).
        /// </summary>
        public static int ToSign(this bool value)
        {
            return value ? 1 : -1;
        }
    }
}
