using EWUConnectMVC.Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWUConnectMVC.Models.Post
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

		public IEnumerable<PostReplyModel> Replies { get; set; }
	}
}
