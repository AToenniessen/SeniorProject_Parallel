using EwuConnect.Domain;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Forums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services
{
	public class ForumService : IForum
	{
		private readonly ApplicationDbContext dbContext;
		public ForumService(ApplicationDbContext context)
		{
			dbContext = context;
		}

		public Task Create(Forum forum)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int forumId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Forum> GetAll()
		{
			return dbContext.Forums.Include(forum => forum.Posts);
		}

		public IEnumerable<ApplicationUser> GetAllActiveUsers()
		{
			throw new NotImplementedException();
		}

		public Forum GetById(int id)
		{
			var forum = dbContext.Forums.Where(f => f.Id == id)
				.Include(f => f.Posts).ThenInclude(p => p.User)
				.Include(f => f.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
				.FirstOrDefault();
			return forum;
		}

		public Task UpdateForumDescription(int forumId, string newDescription)
		{
			throw new NotImplementedException();
		}

		public Task UpdateForumTitle(int forumId, string newTitle)
		{
			throw new NotImplementedException();
		}
	}
}
