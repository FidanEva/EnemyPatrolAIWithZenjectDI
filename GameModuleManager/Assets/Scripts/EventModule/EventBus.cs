using UnityEngine;

namespace EventModule
{
    // temp static
    public static class EventBus
    {
        public static event System.Action<Vector3> OnDirectionAxisUpdated;

        public static void InvokeDirectionAxisUpdated(Vector2 argDirection) =>
            OnDirectionAxisUpdated?.Invoke(argDirection);
    }
}