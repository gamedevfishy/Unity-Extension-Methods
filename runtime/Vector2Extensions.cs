using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Returns a copy with only the given components overridden.
        /// </summary>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
        {
            return new Vector2(x ?? vector.x, y ?? vector.y);
        }

        /// <summary>
        /// Returns a copy with the given components added.
        /// </summary>
        public static Vector2 Add(this Vector2 vector, float? x = null, float? y = null)
        {
            return new Vector2(vector.x + (x ?? 0), vector.y + (y ?? 0));
        }

        /// <summary>
        /// Promotes this vector to a Vector3, using the given Z value.
        /// </summary>
        public static Vector3 ToVector3(this Vector2 vector, float z = 0f)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        /// <summary>
        /// Returns the absolute value of each component.
        /// </summary>
        public static Vector2 Abs(this Vector2 vector)
        {
            return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }

        /// <summary>
        /// Returns the normalized direction from this point to another.
        /// </summary>
        public static Vector2 DirectionTo(this Vector2 from, Vector2 to)
        {
            return (to - from).normalized;
        }

        /// <summary>
        /// Returns the distance between this point and another.
        /// </summary>
        public static float DistanceTo(this Vector2 from, Vector2 to)
        {
            return Vector2.Distance(from, to);
        }

        /// <summary>
        /// Returns true if this vector is within the given tolerance of another.
        /// </summary>
        public static bool IsApproximately(this Vector2 a, Vector2 b, float tolerance = 0.0001f)
        {
            return (a - b).sqrMagnitude <= tolerance * tolerance;
        }

        /// <summary>
        /// Clamps each component of this vector between the matching components of min and max.
        /// </summary>
        public static Vector2 Clamp(this Vector2 vector, Vector2 min, Vector2 max)
        {
            return new Vector2(
                Mathf.Clamp(vector.x, min.x, max.x),
                Mathf.Clamp(vector.y, min.y, max.y));
        }

        /// <summary>
        /// Rotates this vector by the given angle in degrees.
        /// </summary>
        public static Vector2 Rotate(this Vector2 vector, float degrees)
        {
            float rad = degrees * Mathf.Deg2Rad;
            float sin = Mathf.Sin(rad);
            float cos = Mathf.Cos(rad);
            return new Vector2(
                vector.x * cos - vector.y * sin,
                vector.x * sin + vector.y * cos);
        }

        /// <summary>
        /// Returns the 2D cross product (a scalar) of this vector and another.
        /// </summary>
        public static float Cross(this Vector2 a, Vector2 b)
        {
            return a.x * b.y - a.y * b.x;
        }

        /// <summary>
        /// Multiplies this vector component-wise by another.
        /// </summary>
        public static Vector2 Multiply(this Vector2 vector, Vector2 other)
        {
            return new Vector2(vector.x * other.x, vector.y * other.y);
        }

        /// <summary>
        /// Divides this vector component-wise by another.
        /// </summary>
        public static Vector2 Divide(this Vector2 vector, Vector2 other)
        {
            return new Vector2(vector.x / other.x, vector.y / other.y);
        }

        /// <summary>
        /// Returns the squared distance between this point and another.
        /// Cheaper than DistanceTo when only comparing distances.
        /// </summary>
        public static float SqrDistanceTo(this Vector2 from, Vector2 to)
        {
            return (to - from).sqrMagnitude;
        }

        /// <summary>
        /// Returns the midpoint between this vector and another.
        /// </summary>
        public static Vector2 Midpoint(this Vector2 a, Vector2 b)
        {
            return (a + b) * 0.5f;
        }

        /// <summary>
        /// Returns true if this vector is approximately zero.
        /// </summary>
        public static bool IsZero(this Vector2 vector, float tolerance = 0.0001f)
        {
            return vector.sqrMagnitude <= tolerance * tolerance;
        }

        /// <summary>
        /// Returns the angle in degrees between this vector and another.
        /// </summary>
        public static float AngleTo(this Vector2 from, Vector2 to)
        {
            return Vector2.Angle(from, to);
        }

        /// <summary>
        /// Returns a copy of this vector clamped to the given maximum length.
        /// </summary>
        public static Vector2 ClampMagnitude(this Vector2 vector, float maxLength)
        {
            return Vector2.ClampMagnitude(vector, maxLength);
        }

        /// <summary>
        /// Returns this vector rotated 90 degrees clockwise.
        /// </summary>
        public static Vector2 PerpendicularCW(this Vector2 vector)
        {
            return new Vector2(vector.y, -vector.x);
        }

        /// <summary>
        /// Returns this vector rotated 90 degrees counter-clockwise.
        /// </summary>
        public static Vector2 PerpendicularCCW(this Vector2 vector)
        {
            return new Vector2(-vector.y, vector.x);
        }
    }
}
