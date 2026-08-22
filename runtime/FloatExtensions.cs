using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Remaps a value from one range to another.
        /// </summary>
        public static float Remap(this float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            float t = Mathf.InverseLerp(fromMin, fromMax, value);
            return Mathf.Lerp(toMin, toMax, t);
        }

        /// <summary>
        /// Returns true if this value is within the given tolerance of the target value.
        /// Safer than == for floats, and lets you control the tolerance (unlike Mathf.Approximately).
        /// </summary>
        public static bool Approximately(this float value, float target, float tolerance = 0.0001f)
        {
            return Mathf.Abs(value - target) <= tolerance;
        }

        /// <summary>
        /// Returns true if this value is between min and max, inclusive.
        /// </summary>
        public static bool IsInRange(this float value, float min, float max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Rounds this value to the nearest multiple of step.
        /// e.g. 7.3f.Snap(0.5f) == 7.5f
        /// </summary>
        public static float Snap(this float value, float step)
        {
            if (step <= 0f)
                return value;

            return Mathf.Round(value / step) * step;
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        public static float ToRadians(this float degrees)
        {
            return degrees * Mathf.Deg2Rad;
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        public static float ToDegrees(this float radians)
        {
            return radians * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Clamps this value between 0 and 1.
        /// </summary>
        public static float Clamp01(this float value)
        {
            return Mathf.Clamp(value, 0f, 1f);
        }

        /// <summary>
        /// Treats this value as a percentage (0-100) and returns the 0-1 fraction.
        /// </summary>
        public static float PercentToFraction(this float percent)
        {
            return percent * 0.01f;
        }

        /// <summary>
        /// Smoothly moves this value towards a target at a given speed, framerate-independent.
        /// Wraps Mathf.MoveTowards using Time.deltaTime so call sites don't repeat it everywhere.
        /// </summary>
        public static float MoveTowardsPerSecond(this float value, float target, float speed)
        {
            return Mathf.MoveTowards(value, target, speed * Time.deltaTime);
        }

        /// <summary>
        /// Returns -1, 0, or 1 depending on the sign of the value, with a tolerance
        /// around zero to avoid floating point noise flipping the sign randomly.
        /// </summary>
        public static int SignOrZero(this float value, float tolerance = 0.0001f)
        {
            if (value > tolerance)
                return 1;
            if (value < -tolerance)
                return -1;

            return 0;
        }

        /// <summary>
        /// Returns true if this value is approximately zero.
        /// </summary>
        public static bool IsZero(this float value, float tolerance = 0.0001f)
        {
            return Mathf.Abs(value) <= tolerance;
        }
    }
}
