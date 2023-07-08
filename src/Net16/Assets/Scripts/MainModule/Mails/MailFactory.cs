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
            var mail = new Mail(mailStaticData, new List<MailAttachment>());
            return mail;
        }
    }
}