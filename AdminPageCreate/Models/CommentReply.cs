namespace AdminPageCreate.Models
{
    public class CommentReply:BaseModel
    {
        public string ReplyText { get; set; }
        public Comment Comment { get; set; }
    }
}