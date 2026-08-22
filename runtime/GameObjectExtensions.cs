using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Gets the component of type T if present, otherwise adds and returns it.
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.TryGetComponent(out T component) ? component : gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Checks if a component of type T is attached to this object.
        /// </summary>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.TryGetComponent<T>(out _);
        }

        /// <summary>
        /// Sets the layer on this object and recursively on all of its children.
        /// </summary>
        public static void SetLayerRecursively(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetLayerRecursively(layer);
            }
        }

        /// <summary>
        /// Instantiates a copy of this GameObject.
        /// </summary>
        public static GameObject Clone(this GameObject gameObject)
        {
            return Object.Instantiate(gameObject);
        }

        /// <summary>
        /// Destroys this GameObject, optionally after a delay in seconds.
        /// </summary>
        public static void Destroy(this GameObject gameObject, float delay = 0f)
        {
            Object.Destroy(gameObject, delay);
        }

        /// <summary>
        /// Sets the active state only if it differs from the current state,
        /// avoiding redundant SetActive calls.
        /// </summary>
        public static void SetActiveSafe(this GameObject gameObject, bool active)
        {
            if (gameObject != null && gameObject.activeSelf != active)
                gameObject.SetActive(active);
        }

        /// <summary>
        /// Flips this object's active state.
        /// </summary>
        public static void ToggleActive(this GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        /// <summary>
        /// Checks if this object's layer is included in the given LayerMask.
        /// e.g. if (target.IsInLayerMask(attackableMask)) { Attack(); }
        /// </summary>
        public static bool IsInLayerMask(this GameObject gameObject, LayerMask mask)
        {
            return (mask.value & (1 << gameObject.layer)) != 0;
        }
    }
}
