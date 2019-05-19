using EWUConnect.Data;
using EWUConnect.Data.Models;
using EWUConnectMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWUConnect.Service
{
	public class PostService : IPost
	{
		private readonly ApplicationDbContext dbContext;
		public PostService(ApplicationDbContext context)
		{
			dbContext = context;
		}

		public Task Add(Post post)
		{
			throw new NotImplementedException();
		}

		public Task AddReply(PostReply reply)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task EditPostContent(int id, string newContent)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Post> GetAll()
		{
			throw new NotImplementedException();
		}

		public Post GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Post> GetFilteredPosts(string searchQuery)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Post> GetPostsByForum(int id)
		{
			return dbContext.Forums
				.Where(forum => forum.Id == id).First()
				.Posts;
		}
	}
}
