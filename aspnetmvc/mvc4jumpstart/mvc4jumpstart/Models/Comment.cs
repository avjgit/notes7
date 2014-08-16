using System.Security.AccessControl;

namespace mvc4jumpstart.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string User { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int PhotoId { get; set; }
    }
}