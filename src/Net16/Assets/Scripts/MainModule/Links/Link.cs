using UniRx;

namespace MainModule
{
    public sealed class Link
    {
        private readonly ReactiveProperty<bool> _wasRead = new();
        
        public IReadOnlyReactiveProperty<bool> WasRead => _wasRead;
        public LinkStaticData StaticData { get; }

        public Link(LinkStaticData staticData)
        {
            StaticData = staticData;
        }

        public void MarkRead()
        {
            _wasRead.Value = true;
        }
    }
}