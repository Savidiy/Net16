using UnityEngine;
using Zenject;

namespace MainModule
{
    public sealed class HubWindow : BaseWindow
    {
        [Inject]
        public void Construct(Mailbox mailbox)
        {
            Debug.Log("Mails count = " + mailbox.Mails.Count);
        }
    }
}