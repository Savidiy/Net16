using UnityEngine;
using UnityEngine.UI;

namespace MainModule
{
    public abstract class BaseWindow : MonoBehaviour
    {
        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Initialize();
            SubscribeUpdate();
        }

        private void OnDestroy() => 
            Cleanup();

        protected virtual void OnAwake() {}
        protected virtual void Initialize() {}
        protected virtual void SubscribeUpdate() {}
        protected virtual void Cleanup() {}
    }
}