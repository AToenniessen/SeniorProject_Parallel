using EWUConnectMVC.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWUConnect.Bridge.Models.Post
{
	public class PostListingModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string AuthorId { get; set; }
		public string DatePosted { get; set; }

		public ForumListingModel Forum { get; set; }
		public int RepliesCount { get; set; }
	}
}
