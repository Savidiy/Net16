namespace MainModule
{
    public interface IMailsStaticDataProvider
    {
        MailStaticData GetMailStaticData(string mailId);
    }
}