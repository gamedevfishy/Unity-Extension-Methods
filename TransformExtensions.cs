using UnityEngine;

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

    public static bool IsWithinDistance(this Transform transform, Vector3 position, float distance)
    {
        return Vector3.Distance(transform.position, position) <= distance;
    }

    public static bool IsBeyondDistance(this Transform transform, Vector3 position, float distance)
    {
        return Vector3.Distance(transform.position, position) > distance;
    }
}