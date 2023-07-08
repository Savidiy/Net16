using UniRx;

namespace MainModule
{
    public sealed class MailAttachment
    {
        private readonly Inventory _inventory;
        private readonly ReactiveProperty<bool> _wasReceived = new();
        public IReadOnlyReactiveProperty<bool> WasReceived => _wasReceived;
        public AttachmentStaticData StaticData { get; }

        public MailAttachment(AttachmentStaticData staticData, Inventory inventory)
        {
            _inventory = inventory;
            StaticData = staticData;
        }

        public void Receive()
        {
            bool isNotReceived = !_wasReceived.Value;
            if (isNotReceived)
                _inventory.Add(StaticData);


            _wasReceived.Value = true;
        }
    }
}