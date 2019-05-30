using Microsoft.AspNetCore.Identity;
using System;

namespace EwuConnect.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
		public string ProfileImageUrl { get; set; }
		public DateTime MemberSince { get; set; }
		public bool IsActive { get; set; }
    }
}
