namespace GameDevFishy.ExtensionMethods
{
    public static class BoolExtensions
    {
        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }

        public static string ToYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }

        public static bool Toggle(this bool value)
        {
            return !value;
        }

        public static int ToSign(this bool value)
        {
            return value ? 1 : -1;
        }
    }
}
