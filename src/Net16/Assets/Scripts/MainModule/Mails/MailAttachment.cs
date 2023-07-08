using UniRx;

namespace MainModule
{
    public sealed class MailAttachment
    {
        private readonly ReactiveProperty<bool> _wasReceived = new();
        public IReadOnlyReactiveProperty<bool> WasReceived => _wasReceived;
        public AttachmentStaticData StaticData { get; }

        public MailAttachment(AttachmentStaticData staticData)
        {
            StaticData = staticData;
        }
        
        public void Receive()
        {
            _wasReceived.Value = true;
        }
    }
}