using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Models.Forums.ViewModels
{
	public class ForumListingModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}
