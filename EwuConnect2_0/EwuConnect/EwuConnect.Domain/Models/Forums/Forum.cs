using System;
using System.Collections.Generic;
using System.Text;
using EwuConnect.Domain.Models.Posts;

namespace EwuConnect.Domain.Models.Forums
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
