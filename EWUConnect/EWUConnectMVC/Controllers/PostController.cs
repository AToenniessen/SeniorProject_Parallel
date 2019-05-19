using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWUConnect.Data;
using EWUConnect.Data.Models;
using EWUConnectMVC.Models.Post;
using EWUConnectMVC.Models.Reply;
using Microsoft.AspNetCore.Mvc;

namespace EWUConnectMVC.Controllers
{
    public class PostController : Controller
    {
		private readonly IPost post_Service;
		public PostController(IPost postService)
		{
		}

		public IActionResult Index(int id)
        {
			var post = post_Service.GetById(id);
			var replies = BuildPostReplies(post.Replies);

			var model = new PostIndexModel
			{
				Id = post.Id,
				Title = post.Title,
				AuthorId = post.User.Id,
				Author = post.User.UserName,
				AuthorImageUrl = post.User.ProfileImageUrl,
				Created = post.Created,
				PostContent = post.Content,
				Replies = replies
			};
            return View(model);
        }

		private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
		{
			return replies.Select(reply => new PostReplyModel
			{
				Id = reply.Id,
				Author = reply.User.UserName,
				AuthorId = reply.User.Id,
				AuthorImageUrl = reply.User.ProfileImageUrl,
				Created = reply.Created,
				ReplyContent = reply.Content
			});
		}
	}
}