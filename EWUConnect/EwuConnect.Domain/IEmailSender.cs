using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Domain
{
	public interface IEmailSender
	{
		Task<bool> SendEmailAsync(string email, string subject, string message);
	}
}
