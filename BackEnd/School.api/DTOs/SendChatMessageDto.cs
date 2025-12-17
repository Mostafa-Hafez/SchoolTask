namespace School.API.DTOs
{
    public class SendChatMessageDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
    }
    
}
