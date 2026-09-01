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

        /// <summary>
        /// Invokes the given action if this value is true. Returns the original value for chaining.
        /// </summary>
        public static bool IfTrue(this bool value, System.Action action)
        {
            if (value)
                action?.Invoke();

            return value;
        }

        /// <summary>
        /// Invokes the given action if this value is false. Returns the original value for chaining.
        /// </summary>
        public static bool IfFalse(this bool value, System.Action action)
        {
            if (!value)
                action?.Invoke();

            return value;
        }
    }
}
