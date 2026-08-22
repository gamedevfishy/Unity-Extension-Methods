# Unity Extension Methods

A collection of Unity extension methods for `GameObject` and `Transform`, namespaced under `gamedevfishy`.

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
https://github.com/gamedevfishy/Unity-Extension-Methods.git#v1.0.0
```

> Add a `LICENSE` file to the repo before publishing a `v1.0.0` tag.

## Usage

Add the namespace at the top of any script:
```csharp
using gamedevfishy;
```

Then call the extension methods directly on `GameObject` / `Transform` instances.

### `TransformExtensions`

| Method | Description |
|---|---|
| `transform.LookAtConstrained(target, allowedAxes)` | Looks at `target` but only rotates around the axes you allow. |
| `transform.IsWithinDistance(position, distance)` | Returns `true` if the transform is within `distance` of `position`. |
| `transform.IsBeyondDistance(position, distance)` | Returns `true` if the transform is farther than `distance` from `position`. |

#### Example
```csharp
using UnityEngine;
using gamedevfishy;

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
