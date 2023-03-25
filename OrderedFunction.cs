using UnityEngine;

namespace Utility
{
    public abstract class OrderedFunction : MonoBehaviour
    {
        public abstract void OnEntry();

        public abstract void OnUpdate();

        public abstract void OnExit();
    }
}