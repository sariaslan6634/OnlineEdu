namespace OnlineEdu.WebUI.DTOS.MessageDtos
{
    public class CreateReplyDto
    {
        public int MessageId { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
