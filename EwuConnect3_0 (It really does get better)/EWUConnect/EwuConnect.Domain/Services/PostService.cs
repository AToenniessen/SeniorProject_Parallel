using EwuConnect.Domain.Models.Posts;
using EwuConnect.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services
{
	public class PostService : IPost
	{
		private readonly ApplicationDbContext dbContext;
		public PostService(ApplicationDbContext context)
		{
			dbContext = context;
		}

		public async Task Add(Post post)
		{
			dbContext.Add(post);
			await dbContext.SaveChangesAsync();
		}

		public async Task AddReply(PostReply reply)
		{
			dbContext.Add(reply);
			await dbContext.SaveChangesAsync();
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
			return dbContext.Posts
				.Include(post => post.User)
				.Include(post => post.Replies).ThenInclude(reply => reply.User)
				.Include(post => post.Forum);
		}

		public Post GetById(int id)
		{
			return dbContext.Posts.Where(post => post.Id == id)
				.Include(post => post.User)
				.Include(post => post.Replies).ThenInclude(reply => reply.User)
				.Include(post => post.Forum)
				.FirstOrDefault();
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
