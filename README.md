# Unity Extension Methods
A collection of Unity extension methods for `Transform`, `GameObject`, `Vector3`, `Vector2`, `Quaternion`, `float`, `int`, `string`, and `bool`.

## Installation (via Unity Package Manager)
1. In Unity, open **Window → Package Manager**.
2. Click the **+** button → **Add package from git URL…**
3. Paste:
   ```
   https://github.com/gamedevfishy/Unity-Extension-Methods.git
   ```
4. Click **Add**.

To pin to a specific version, append a tag or branch:
```
https://github.com/gamedevfishy/Unity-Extension-Methods.git#v1.2.0
```

## Usage
Add the namespace at the top of any script:
```csharp
using GameDevFishy.ExtensionMethods;
```
Then call the extension methods directly on the relevant type.

### `TransformExtensions`
| Method | Description |
|---|---|
| `transform.LookAtConstrained(target, allowedAxes)` | Looks at `target` but only rotates around the axes you allow. |
| `transform.IsWithinDistance(position, distance)` | Returns `true` if within `distance` of `position`. |
| `transform.IsBeyondDistance(position, distance)` | Returns `true` if farther than `distance` from `position`. |
| `transform.SetX(x)` / `SetY(y)` / `SetZ(z)` | Sets a single axis of world position. |
| `transform.Reset()` | Resets local position, rotation, and scale. |
| `transform.CopyFrom(other)` | Copies position, rotation, and scale from another transform. |
| `transform.Children()` | Enumerates direct children. |
| `transform.PerformActionOnChildren(action)` | Runs an action on every direct child, returns count affected. |
| `transform.DestroyAllChildren()` | Destroys all direct children, returns count destroyed. |
| `transform.SetChildrenActive(active)` | Enables/disables all direct children, returns count affected. |
| `transform.FindClosest(others)` | Returns the closest transform from a collection. |
| `transform.GetPath(delimiter)` | Builds the full hierarchy path. |
| `transform.SetParentAndReset(parent)` | Reparents and resets local transform. |
| `transform.LookAt2D(target)` | Faces a target on the X/Y plane (2D). |

### `GameObjectExtensions`
| Method | Description |
|---|---|
| `gameObject.GetOrAddComponent<T>()` | Gets the component if present, otherwise adds and returns it. |
| `gameObject.HasComponent<T>()` | Checks if a component is attached. |
| `gameObject.SetLayerRecursively(layer)` | Sets the layer on this object and all children. |
| `gameObject.Clone()` | Instantiates a copy of this object. |
| `gameObject.Destroy(delay)` | Destroys the object, optionally after a delay. |
| `gameObject.SetActiveSafe(active)` | Sets active state only if it's actually different (avoids redundant calls). |
| `gameObject.ToggleActive()` | Flips the object's active state. |
| `gameObject.IsInLayerMask(mask)` | Checks if the object's layer is included in a `LayerMask`. |

### `Vector3Extensions`
| Method | Description |
|---|---|
| `vector.With(x, y, z)` | Returns a copy with only the given components overridden. |
| `vector.Add(x, y, z)` | Returns a copy with the given components added. |
| `vector.ToVector2()` | Drops the Z component. |
| `vector.Flatten()` | Zeroes the Y component. |
| `vector.Abs()` | Absolute value of each component. |
| `from.DirectionTo(to)` | Normalized direction between two points. |
| `from.DistanceTo(to)` | Distance between two points. |
| `a.IsApproximately(b, tolerance)` | Tolerance-based equality check. |
| `vector.Clamp(min, max)` | Clamps each component between min and max. |
| `center.RandomPointInRadius(radius)` | Random point inside a sphere around center. |

### `Vector2Extensions`
| Method | Description |
|---|---|
| `vector.With(x, y)` | Returns a copy with only the given components overridden. |
| `vector.Add(x, y)` | Returns a copy with the given components added. |
| `vector.ToVector3(z)` | Promotes to a Vector3. |
| `vector.Abs()` | Absolute value of each component. |
| `from.DirectionTo(to)` | Normalized direction between two points. |
| `from.DistanceTo(to)` | Distance between two points. |
| `a.IsApproximately(b, tolerance)` | Tolerance-based equality check. |
| `vector.Clamp(min, max)` | Clamps each component between min and max. |
| `vector.Rotate(degrees)` | Rotates the vector by an angle in degrees. |
| `a.Cross(b)` | 2D cross product (scalar). |

### `QuaternionExtensions`
| Method | Description |
|---|---|
| `rotation.With(x, y, z)` | Returns a copy with only the given Euler components overridden. |
| `rotation.Add(x, y, z)` | Returns a copy with the given Euler components added. |
| `a.IsApproximately(b, tolerance)` | Tolerance-based rotation equality check. |
| `rotation.Inverse()` | Returns the inverse rotation. |
| `rotation.Forward()` / `Right()` / `Up()` | Returns the corresponding direction vector for this rotation. |
| `rotation.RotateTowardsPerSecond(target, degreesPerSecond)` | Frame-rate independent rotate towards target. |
| `rotation.Flip180()` | Returns the rotation flipped 180° around Y. |

### `FloatExtensions`
| Method | Description |
|---|---|
| `value.Remap(fromMin, fromMax, toMin, toMax)` | Remaps a value between two ranges. |
| `value.Approximately(target, tolerance)` | Tolerance-based equality check. |
| `value.IsInRange(min, max)` | Inclusive range check. |
| `value.Snap(step)` | Rounds to the nearest multiple of `step`. |
| `degrees.ToRadians()` / `radians.ToDegrees()` | Angle unit conversion. |
| `value.Clamp01()` | Clamps between 0 and 1. |
| `percent.PercentToFraction()` | Converts 0–100 to 0–1. |
| `value.MoveTowardsPerSecond(target, speed)` | Frame-rate independent move towards target. |
| `value.SignOrZero(tolerance)` | Returns -1, 0, or 1, with a deadzone around zero. |
| `value.IsZero(tolerance)` | Tolerance-based zero check. |

### `IntExtensions`
| Method | Description |
|---|---|
| `value.IsInRange(min, max)` | Inclusive range check. |
| `value.IsEven()` / `IsOdd()` | Parity check. |
| `value.Clamp(min, max)` | Clamps the value. |
| `value.Abs()` | Absolute value. |
| `value.Wrap(min, max)` | Wraps a value within a range (e.g. for cyclic indices). |
| `value.IsBitSet(bitIndex)` | Checks if a bit is set. |
| `value.SetBit(bitIndex, state)` | Sets or clears a bit. |
| `value.ToPercentOf(total)` | Returns value as a percentage of total. |
| `layer.CreateFromLayer()` | Creates a single-layer `LayerMask` from a layer index. |

### `StringExtensions`
| Method | Description |
|---|---|
| `value.IsNullOrEmpty()` / `IsNullOrWhiteSpace()` | Null/empty checks as instance calls. |
| `value.Truncate(maxLength, suffix)` | Truncates with an optional suffix. |
| `value.ToTitleCase()` | Converts to Title Case. |
| `value.ContainsIgnoreCase(other)` | Case-insensitive contains check. |
| `value.RemoveWhitespace()` | Strips all whitespace. |
| `value.IsNumeric()` | Checks if the string parses as a number. |
| `value.Reverse()` | Reverses the string. |
| `value.ToSnakeCase()` / `ToCamelCase()` | Case style conversion. |

### `BoolExtensions`
| Method | Description |
|---|---|
| `value.ToInt()` | Converts to 1 or 0. |
| `value.ToYesNo()` | Converts to `"Yes"` / `"No"`. |
| `value.Toggle()` | Returns the negated value. |
| `value.ToSign()` | Converts to 1 or -1. |

## Example
```csharp
using UnityEngine;
using GameDevFishy.ExtensionMethods;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public float alertDistance = 10f;

    void Update()
    {
        if (transform.IsWithinDistance(player.position, alertDistance))
        {
            // Only rotate around Y so the transform stays upright.
            transform.LookAtConstrained(player.position, RotationAxis.Y);
        }
    }
}
```

## License
MIT — see [LICENSE](LICENSE).
