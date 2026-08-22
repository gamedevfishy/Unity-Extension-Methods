using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsInRange(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        public static int Clamp(this int value, int min, int max)
        {
            return Mathf.Clamp(value, min, max);
        }

        public static int Abs(this int value)
        {
            return Mathf.Abs(value);
        }

        public static int Wrap(this int value, int min, int max)
        {
            int range = max - min + 1;
            return min + ((value - min) % range + range) % range;
        }

        public static bool IsBitSet(this int value, int bitIndex)
        {
            return (value & (1 << bitIndex)) != 0;
        }

        public static int SetBit(this int value, int bitIndex, bool state)
        {
            return state ? value | (1 << bitIndex) : value & ~(1 << bitIndex);
        }

        public static float ToPercentOf(this int value, int total)
        {
            return total == 0 ? 0f : (float)value / total * 100f;
        }
    }
}
