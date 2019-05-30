using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Models.Replies.ViewModels
{
	public class PostReplyModel
	{
		public int Id { get; set; }
		public string AuthorId { get; set; }
		public string Author { get; set; }
		public string AuthorImageUrl { get; set; }
		public DateTime Created { get; set; }
		public string ReplyContent { get; set; }
		public bool isAuthorAdmin { get; set; }
		public int PostId { get; set; }
	}
}
