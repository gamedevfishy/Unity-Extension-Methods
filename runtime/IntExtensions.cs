using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns true if this value is between min and max, inclusive.
        /// </summary>
        public static bool IsInRange(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Returns true if this value is even.
        /// </summary>
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Returns true if this value is odd.
        /// </summary>
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        /// <summary>
        /// Clamps this value between min and max.
        /// </summary>
        public static int Clamp(this int value, int min, int max)
        {
            return Mathf.Clamp(value, min, max);
        }

        /// <summary>
        /// Returns the absolute value.
        /// </summary>
        public static int Abs(this int value)
        {
            return Mathf.Abs(value);
        }

        /// <summary>
        /// Wraps this value within a range, useful for cyclic indices (e.g. looping through an array).
        /// </summary>
        public static int Wrap(this int value, int min, int max)
        {
            int range = max - min + 1;
            return min + ((value - min) % range + range) % range;
        }

        /// <summary>
        /// Checks if the bit at the given index is set.
        /// </summary>
        public static bool IsBitSet(this int value, int bitIndex)
        {
            return (value & (1 << bitIndex)) != 0;
        }

        /// <summary>
        /// Sets or clears the bit at the given index.
        /// </summary>
        public static int SetBit(this int value, int bitIndex, bool state)
        {
            return state ? value | (1 << bitIndex) : value & ~(1 << bitIndex);
        }

        /// <summary>
        /// Returns this value as a percentage of total (0-100 range).
        /// </summary>
        public static float ToPercentOf(this int value, int total)
        {
            return total == 0 ? 0f : (float)value / total * 100f;
        }

        /// <summary>
        /// Creates a single-layer LayerMask from a layer index.
        /// e.g. LayerMask playerOnly = playerLayer.CreateFromLayer();
        /// </summary>
        public static LayerMask CreateFromLayer(this int layer)
        {
            return 1 << layer;
        }

        /// <summary>
        /// Returns the value multiplied by itself.
        /// </summary>
        public static int Squared(this int value)
        {
            return value * value;
        }

        /// <summary>
        /// Returns the value raised to the third power.
        /// </summary>
        public static int Cubed(this int value)
        {
            return value * value * value;
        }

        /// <summary>
        /// Clamps this value so it is never less than min (no upper bound).
        /// </summary>
        public static int ClampMin(this int value, int min)
        {
            return value < min ? min : value;
        }

        /// <summary>
        /// Clamps this value so it is never greater than max (no lower bound).
        /// </summary>
        public static int ClampMax(this int value, int max)
        {
            return value > max ? max : value;
        }

        /// <summary>
        /// Returns true if this value is a power of two.
        /// </summary>
        public static bool IsPowerOfTwo(this int value)
        {
            return value > 0 && (value & (value - 1)) == 0;
        }

        /// <summary>
        /// Returns -1, 0, or 1 depending on the sign of the value.
        /// </summary>
        public static int Sign(this int value)
        {
            return (int)Mathf.Sign(value);
        }
    }
}
