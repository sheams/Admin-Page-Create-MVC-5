using System.Collections.Generic;

namespace AdminPageCreate.Models
{
    public class Comment:BaseModel
    {
        public string CommentText { get; set; }
        public Page Page { get; set; }
        public List<CommentReply> Reply { get; set; }
    }
}