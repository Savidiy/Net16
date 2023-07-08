using System.Collections.Generic;

namespace MainModule
{
    public class MailFactory
    {
        private readonly IMailStaticDataProvider _mailsStaticData;

        public MailFactory(IMailStaticDataProvider mailsStaticData)
        {
            _mailsStaticData = mailsStaticData;
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

        private static List<MailAttachment> CreateMailAttachments(MailStaticData mailStaticData)
        {
            var mailAttachments = new List<MailAttachment>();
            foreach (AttachmentStaticData attachmentStaticData in mailStaticData.Attachments)
                mailAttachments.Add(new MailAttachment(attachmentStaticData));

            return mailAttachments;
        }
    }
}