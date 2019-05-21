﻿using EwuConnect.Domain.Models.Posts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Models.Forums.ViewModels
{
	public class ForumTopicModel
	{
		public ForumListingModel Forum { get; set; }
		public IEnumerable<PostListingModel> Posts { get; set; }
	}
}
