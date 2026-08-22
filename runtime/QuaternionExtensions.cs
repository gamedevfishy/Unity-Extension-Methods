using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    public static class QuaternionExtensions
    {
        /// <summary>
        /// Returns a copy with only the given Euler components overridden.
        /// </summary>
        public static Quaternion With(this Quaternion rotation, float? x = null, float? y = null, float? z = null)
        {
            Vector3 euler = rotation.eulerAngles;
            return Quaternion.Euler(x ?? euler.x, y ?? euler.y, z ?? euler.z);
        }

        /// <summary>
        /// Returns a copy with the given Euler components added.
        /// </summary>
        public static Quaternion Add(this Quaternion rotation, float? x = null, float? y = null, float? z = null)
        {
            Vector3 euler = rotation.eulerAngles;
            return Quaternion.Euler(euler.x + (x ?? 0), euler.y + (y ?? 0), euler.z + (z ?? 0));
        }

        /// <summary>
        /// Returns true if this rotation is within the given tolerance of another.
        /// </summary>
        public static bool IsApproximately(this Quaternion a, Quaternion b, float tolerance = 0.0001f)
        {
            return 1f - Mathf.Abs(Quaternion.Dot(a, b)) <= tolerance;
        }

        /// <summary>
        /// Returns the inverse of this rotation.
        /// </summary>
        public static Quaternion Inverse(this Quaternion rotation)
        {
            return Quaternion.Inverse(rotation);
        }

        /// <summary>
        /// Returns the forward direction vector for this rotation.
        /// </summary>
        public static Vector3 Forward(this Quaternion rotation)
        {
            return rotation * Vector3.forward;
        }

        /// <summary>
        /// Returns the right direction vector for this rotation.
        /// </summary>
        public static Vector3 Right(this Quaternion rotation)
        {
            return rotation * Vector3.right;
        }

        /// <summary>
        /// Returns the up direction vector for this rotation.
        /// </summary>
        public static Vector3 Up(this Quaternion rotation)
        {
            return rotation * Vector3.up;
        }

        /// <summary>
        /// Frame-rate independent rotate towards a target rotation, at a given speed in degrees per second.
        /// </summary>
        public static Quaternion RotateTowardsPerSecond(this Quaternion rotation, Quaternion target, float degreesPerSecond)
        {
            return Quaternion.RotateTowards(rotation, target, degreesPerSecond * Time.deltaTime);
        }

        /// <summary>
        /// Returns this rotation flipped 180 degrees around the Y axis.
        /// </summary>
        public static Quaternion Flip180(this Quaternion rotation)
        {
            return rotation * Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
