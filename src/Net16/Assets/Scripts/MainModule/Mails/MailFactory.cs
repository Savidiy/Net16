using System.Collections.Generic;

namespace MainModule
{
    public class MailFactory
    {
        private readonly IMailStaticDataProvider _mailsStaticData;
        private readonly Inventory _inventory;

        public MailFactory(IMailStaticDataProvider mailsStaticData, Inventory inventory)
        {
            _mailsStaticData = mailsStaticData;
            _inventory = inventory;
        }
        
        public Mail CreateMail(MailId mailId)
        {
            return CreateMail(mailId.Id);
        }

        private Mail CreateMail(string mailId)
        {
            MailStaticData mailStaticData = _mailsStaticData.GetMailStaticData(mailId);
            
            List<MailAttachment> mailAttachments = CreateMailAttachments(mailStaticData);

            var mail = new Mail(mailStaticData, mailAttachments);
            return mail;
        }

        private List<MailAttachment> CreateMailAttachments(MailStaticData mailStaticData)
        {
            var mailAttachments = new List<MailAttachment>();
            foreach (AttachmentStaticData attachmentStaticData in mailStaticData.Attachments)
                mailAttachments.Add(new MailAttachment(attachmentStaticData, _inventory));

            return mailAttachments;
        }
    }
}