﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Models.ContactViewModel
{
	public class ContactViewModel
	{
		[Required(ErrorMessage = "Please enter your first name")]
		[RegularExpression(@"^[A-z\-']{1,50}$", ErrorMessage = "Please enter a valid first name")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Please enter your last name")]
		[RegularExpression(@"^[A-z\-']{1,50}$", ErrorMessage = "Please enter a valid last name")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Please enter an Email address")]
		[EmailAddress]
		[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid Email address")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please enter a message to send")]
		[RegularExpression(@"(\w*\s*[!?\.'-]*)*")]
		public string Comment { get; set; }
		public bool isSent { get; set; }
	}
}
