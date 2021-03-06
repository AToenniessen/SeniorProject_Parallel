﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Models.Posts.ViewModels
{
	public class NewPostModel
	{
		public string ForumName { get; set; }
		public int ForumId { get; set; }
		public string Author { get; set; }
		public string ForumImageUrl { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
	}
}
