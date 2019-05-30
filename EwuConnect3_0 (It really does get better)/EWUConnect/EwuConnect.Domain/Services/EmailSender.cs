using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services
{
	// This class is used by the application to send email for account confirmation and password reset.
	// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
	public class EmailSender : IEmailSender
	{
		
		public async Task<bool> SendEmailAsync(string email, string subject, string message)
		{
			try
			{
				MailMessage mail = new MailMessage();
				const string fromAddress = "connectewu@gmail.com";
				mail.From = new MailAddress(fromAddress);
				mail.To.Add(new MailAddress(email));
				const string fromPassword = "Nate Bryant";

				mail.Subject = subject;

				string body = message;


				SmtpClient smtp = new SmtpClient();
				smtp.Port = 587;
				smtp.EnableSsl = true;
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
				smtp.Host = "smtp.gmail.com";
				smtp.Timeout = 10000;

				mail.IsBodyHtml = true;
				mail.Body = body;
				await smtp.SendMailAsync(mail);

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				//Comments.Text = ex.ToString();
			}
			return false;
		}
	}
}
