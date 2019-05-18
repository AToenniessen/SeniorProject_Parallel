using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWUConnect.Data;
using EWUConnectMVC.Models.Forum;
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
			var posts = post_Service.GetFilteredPosts(id);

			var postListings = 
		}
    }
}