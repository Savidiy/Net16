using System;

namespace MainModule
{
    [Serializable]
    public sealed class WindowConfig
    {
        public WindowId Id;
        public BaseWindow Prefab;
    }
}