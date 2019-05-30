using EwuConnect.Domain.Models.Replies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Models.Posts.ViewModels
{
	public class PostIndexModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string AuthorId { get; set; }
		public string Author { get; set; }
		public string AuthorImageUrl { get; set; }
		public DateTime Created { get; set; }
		public string PostContent { get; set; }

		public int ForumId { get; set; }
		public string ForumName { get; set; }
		public bool isAuthorAdmin { get; set; }

		public IEnumerable<PostReplyModel> Replies { get; set; }
	}
}
