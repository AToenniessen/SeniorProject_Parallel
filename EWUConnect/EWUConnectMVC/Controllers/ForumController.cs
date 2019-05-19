using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWUConnect.Data;
using EWUConnect.Data.Models;
using EWUConnectMVC.Models.Forum;
using EWUConnectMVC.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace EWUConnectMVC.Controllers
{
    public class ForumController : Controller
    {
		private readonly IForum forum_Service;
		private readonly IPost post_Service;
		public ForumController(IForum forumService)
		{
			forum_Service = forumService;
		}

		public IActionResult Index()
		{
			var forums = forum_Service.GetAll()
				.Select(forum => new ForumListingModel {
					Id = forum.Id,
					Name = forum.Title,
					Description = forum.Description
				});

			var model = new ForumIndexModel
			{
				ForumList = forums
			};
            return View(model);
        }
		public IActionResult Topic(int id)
		{
			var forum = forum_Service.GetById(id);
			var posts = forum.Posts;

			var postListings = posts.Select(post => new PostListingModel
			{
				Id = post.Id,
				AuthorId = post.User.Id,
				Title = post.Title,
				DatePosted = post.Created.ToString(),
				RepliesCount = post.Replies.Count(),
				Forum = BuildForumListing(post)
			});

			var model = new ForumTopicModel
			{
				Posts = postListings,
				Forum = BuildForumListing(forum)
			};

			return View(model);
		}

		private ForumListingModel BuildForumListing(Post post)
		{
			var forum = post.Forum;

			return BuildForumListing(forum);
		}
		private ForumListingModel BuildForumListing(Forum forum)
		{
			return new ForumListingModel
			{
				Id = forum.Id,
				Name = forum.Title,
				Description = forum.Description,
				ImageUrl = forum.ImageUrl
			};
		}
	}
}