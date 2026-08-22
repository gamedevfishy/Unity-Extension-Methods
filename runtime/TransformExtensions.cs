using System.Collections.Generic;
using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    [System.Flags]
    public enum RotationAxis
    {
        X = 1,
        Y = 2,
        Z = 4
    }

    public static class TransformExtensions
    {
        /// <summary>
        /// Rotates the transform to look at the target while preserving constrained Euler axes.
        /// </summary>
        public static void LookAtConstrained(this Transform transform, Vector3 target, RotationAxis allowedAxes)
        {
            Quaternion lookRotation = Quaternion.LookRotation(target - transform.position);

            Vector3 euler = transform.eulerAngles;
            Vector3 targetEuler = lookRotation.eulerAngles;

            if ((allowedAxes & RotationAxis.X) != 0)
                euler.x = targetEuler.x;

            if ((allowedAxes & RotationAxis.Y) != 0)
                euler.y = targetEuler.y;

            if ((allowedAxes & RotationAxis.Z) != 0)
                euler.z = targetEuler.z;

            transform.rotation = Quaternion.Euler(euler);
        }

        /// <summary>
        /// Returns true if this transform is within the given distance of a position.
        /// </summary>
        public static bool IsWithinDistance(this Transform transform, Vector3 position, float distance)
        {
            return Vector3.Distance(transform.position, position) <= distance;
        }

        /// <summary>
        /// Returns true if this transform is farther than the given distance from a position.
        /// </summary>
        public static bool IsBeyondDistance(this Transform transform, Vector3 position, float distance)
        {
            return Vector3.Distance(transform.position, position) > distance;
        }

        /// <summary>
        /// Sets the X component of the transform's world position.
        /// </summary>
        public static void SetX(this Transform transform, float x)
        {
            Vector3 pos = transform.position;
            pos.x = x;
            transform.position = pos;
        }

        /// <summary>
        /// Sets the Y component of the transform's world position.
        /// </summary>
        public static void SetY(this Transform transform, float y)
        {
            Vector3 pos = transform.position;
            pos.y = y;
            transform.position = pos;
        }

        /// <summary>
        /// Sets the Z component of the transform's world position.
        /// </summary>
        public static void SetZ(this Transform transform, float z)
        {
            Vector3 pos = transform.position;
            pos.z = z;
            transform.position = pos;
        }

        /// <summary>
        /// Resets local position to zero, local rotation to identity, and local scale to one.
        /// </summary>
        public static void Reset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Copies position, rotation, and scale from another transform.
        /// </summary>
        public static void CopyFrom(this Transform transform, Transform other)
        {
            transform.position = other.position;
            transform.rotation = other.rotation;
            transform.localScale = other.localScale;
        }

        /// <summary>
        /// Enumerates all direct children of this transform.
        /// </summary>
        public static IEnumerable<Transform> Children(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                yield return child;
            }
        }

        /// <summary>
        /// Runs the given action on every direct child of this transform (reverse order,
        /// so it's safe even if the action destroys/reparents children). Returns how many were affected.
        /// </summary>
        public static int PerformActionOnChildren(this Transform parent, System.Action<Transform> action)
        {
            int count = 0;
            for (var i = parent.childCount - 1; i >= 0; i--)
            {
                action(parent.GetChild(i));
                count++;
            }

            return count;
        }

        /// <summary>
        /// Destroys all direct children of this transform. Returns how many were destroyed.
        /// </summary>
        public static int DestroyAllChildren(this Transform transform)
        {
            return transform.PerformActionOnChildren(child => Object.Destroy(child.gameObject));
        }

        /// <summary>
        /// Enables or disables all direct children of this transform. Returns how many were affected.
        /// </summary>
        public static int SetChildrenActive(this Transform transform, bool active)
        {
            return transform.PerformActionOnChildren(child => child.gameObject.SetActive(active));
        }

        /// <summary>
        /// Returns the transform in the given collection that is closest to this transform.
        /// </summary>
        public static Transform FindClosest(this Transform transform, IEnumerable<Transform> others)
        {
            Transform closest = null;
            float closestSqrDist = float.MaxValue;

            foreach (Transform other in others)
            {
                if (other == null || other == transform)
                    continue;

                float sqrDist = (other.position - transform.position).sqrMagnitude;
                if (sqrDist < closestSqrDist)
                {
                    closestSqrDist = sqrDist;
                    closest = other;
                }
            }

            return closest;
        }

        /// <summary>
        /// Builds the full hierarchy path of this transform, from the root down to this object.
        /// </summary>
        public static string GetPath(this Transform transform, string delimiter = "/")
        {
            string path = transform.name;
            Transform current = transform.parent;

            while (current != null)
            {
                path = current.name + delimiter + path;
                current = current.parent;
            }

            return path;
        }

        /// <summary>
        /// Sets the parent of this transform and immediately resets its local position,
        /// rotation, and scale relative to the new parent.
        /// </summary>
        public static void SetParentAndReset(this Transform transform, Transform parent)
        {
            transform.SetParent(parent, false);
            transform.Reset();
        }

        /// <summary>
        /// Rotates the transform's up-axis to face a target position, ignoring the Z axis.
        /// Useful for 2D games using X/Y as the movement plane.
        /// </summary>
        public static void LookAt2D(this Transform transform, Vector3 target)
        {
            Vector3 direction = target - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}