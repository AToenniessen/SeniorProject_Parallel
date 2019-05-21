using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Models.Forums.ViewModels
{
	public class ForumIndexModel
	{
		public IEnumerable<ForumListingModel> ForumList { get; set; }
	}
}
