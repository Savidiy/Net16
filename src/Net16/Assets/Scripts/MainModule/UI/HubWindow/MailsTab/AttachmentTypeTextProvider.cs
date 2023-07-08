namespace MainModule
{
    internal class AttachmentTypeTextProvider
    {
        public string GetCollectText(AttachmentType attachmentType)
        {
            return attachmentType switch
            {
                AttachmentType.Link => "Save link",
                AttachmentType.File => "Download",
                _ => "Unknown type"
            };
        }
    }
}