using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EwuConnect.Domain.Models.MentorViewModel
{
	public class MentorViewModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name")]
		[RegularExpression(@"^[A-Za-z\-']{1,50}$", ErrorMessage = "Please enter a valid first name")]
		public string FirstName { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name")]
		[RegularExpression(@"^[A-Za-z\-']{1,50}$", ErrorMessage = "Please enter a valid last name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter an Email address")]
		[EmailAddress]
		[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid Email address")]
		public string Email { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a message to send (Limit 500 characters)")]
		[RegularExpression(@"^([A-Za-z!?\,\.\s\-']{1,500})$")]
		public string Comment { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an area code")]
		[RegularExpression(@"^[0-9]{3}$", ErrorMessage ="Invalid")]
		public string AreaCode { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a prefix")]
		[RegularExpression(@"^[0-9]{3}$", ErrorMessage ="Invalid")]
		public string FirstPhone { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a line number")]
		[RegularExpression(@"^[0-9]{4}$", ErrorMessage ="Invalid")]
		public string LastPhone { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Company/University association")]
		[RegularExpression(@"^[A-Za-z\-' ]{1,50}$", ErrorMessage = "Please enter valid Company/University")]
		public string Association { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Major")]
		[RegularExpression(@"^[A-Za-z\-' ]{1,50}$", ErrorMessage = "Please enter a valid Major")]
		public string Major { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter graduation year")]
		[RegularExpression(@"^[12][09][0-9]{2}$", ErrorMessage = "Please enter a valid year")]
		public string Graduated { get; set; }
		public bool isSent { get; set; }
	}
}
