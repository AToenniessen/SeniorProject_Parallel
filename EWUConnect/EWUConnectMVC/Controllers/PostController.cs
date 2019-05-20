using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWUConnect.Data;
using EWUConnect.Data.Models;
using EWUConnectMVC.Models.Post;
using EWUConnectMVC.Models.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EWUConnectMVC.Controllers
{
	public class PostController : Controller
	{
		private readonly IPost post_Service;
		private readonly IForum forum_Service;

		private static UserManager<ApplicationUser> user_Manager;


		public PostController(IPost postService, IForum forumService, UserManager<ApplicationUser> userManager)
		{
			post_Service = postService;
			forum_Service = forumService;
			user_Manager = userManager;
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
		
		public IActionResult Create(int id)
		{
			var forum = forum_Service.GetById(id);

			var model = new NewPostModel
			{
				Title = forum.Title,
				ForumId = forum.Id,
				ForumImageUrl = forum.ImageUrl,
				Author = User.Identity.Name
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddPost(NewPostModel model)
		{
			var user = await user_Manager.FindByIdAsync(user_Manager.GetUserId(User));
			if (user != null)
			{
				var post = BuildPost(model, user);

				await post_Service.Add(post);

				return RedirectToAction("Index", "Post", new { id = post.Id });
			}
			else
				return Redirect("/Account/Login");
		}

		private Post BuildPost(NewPostModel model, ApplicationUser user)
		{
			var forum = forum_Service.GetById(model.ForumId);
			return new Post
			{
				Title = model.Title,
				Content = model.Content,
				Created = DateTime.Now,
				User = user,
				Forum = forum
			};
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