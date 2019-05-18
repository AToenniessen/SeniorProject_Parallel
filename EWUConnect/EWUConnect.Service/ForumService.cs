using EWUConnect.Data;
using EWUConnect.Data.Models;
using EWUConnectMVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EWUConnect.Service
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
			throw new NotImplementedException();
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
