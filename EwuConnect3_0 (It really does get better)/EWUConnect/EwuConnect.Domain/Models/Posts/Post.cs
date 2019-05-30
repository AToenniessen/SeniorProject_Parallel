using System;
using System.Collections.Generic;
using EwuConnect.Domain.Models.Forums;
using System.Text;

namespace EwuConnect.Domain.Models.Posts
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Forum Forum { get; set; }
        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}
