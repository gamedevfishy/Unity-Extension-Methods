using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Returns a copy with only the given components overridden.
        /// </summary>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Returns a copy with the given components added.
        /// </summary>
        public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
        }

        /// <summary>
        /// Drops the Z component and returns a Vector2.
        /// </summary>
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        /// <summary>
        /// Zeroes the Y component, projecting the vector onto the XZ plane.
        /// </summary>
        public static Vector3 Flatten(this Vector3 vector)
        {
            return new Vector3(vector.x, 0f, vector.z);
        }

        /// <summary>
        /// Returns the absolute value of each component.
        /// </summary>
        public static Vector3 Abs(this Vector3 vector)
        {
            return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        }

        /// <summary>
        /// Returns the normalized direction from this point to another.
        /// </summary>
        public static Vector3 DirectionTo(this Vector3 from, Vector3 to)
        {
            return (to - from).normalized;
        }

        /// <summary>
        /// Returns the distance between this point and another.
        /// </summary>
        public static float DistanceTo(this Vector3 from, Vector3 to)
        {
            return Vector3.Distance(from, to);
        }

        /// <summary>
        /// Returns true if this vector is within the given tolerance of another.
        /// </summary>
        public static bool IsApproximately(this Vector3 a, Vector3 b, float tolerance = 0.0001f)
        {
            return (a - b).sqrMagnitude <= tolerance * tolerance;
        }

        /// <summary>
        /// Clamps each component of this vector between the matching components of min and max.
        /// </summary>
        public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
        {
            return new Vector3(
                Mathf.Clamp(vector.x, min.x, max.x),
                Mathf.Clamp(vector.y, min.y, max.y),
                Mathf.Clamp(vector.z, min.z, max.z));
        }

        /// <summary>
        /// Returns a random point inside a sphere of the given radius, centered on this vector.
        /// </summary>
        public static Vector3 RandomPointInRadius(this Vector3 center, float radius)
        {
            return center + Random.insideUnitSphere * radius;
        }
    }
}
