using System.Collections.Generic;

namespace MainModule
{
    public class Mail
    {
        public List<MailAttachment> Attachments { get; }
        public MailStaticData StaticData;
        public bool WasRead { get; private set; }

        public Mail(MailStaticData staticData, List<MailAttachment> attachments)
        {
            Attachments = attachments;
            StaticData = staticData;
        }

        public void MarkRead()
        {
            WasRead = true;
        }

        public bool IsAllAttachmentsReceived()
        {
            foreach (MailAttachment mailAttachment in Attachments)
            {
                if (!mailAttachment.WasReceived)
                    return false;
            }

            return true;
        }
    }
}