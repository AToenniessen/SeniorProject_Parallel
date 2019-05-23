using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using EwuConnect.Domain.Models.ContactViewModel;

namespace EwuConnect.Domain.Services
{
	public class ContactService : IContact
	{
		public bool sendMail(ContactViewModel viewModel)
		{
			try
			{
				MailMessage mail = new MailMessage();
				const string fromAddress = "connectewu@gmail.com";
				mail.From = new MailAddress(fromAddress);
				mail.To.Add(new MailAddress(viewModel.Email));
				const string fromPassword = "Nate Bryant";

				mail.Subject = "EWU CONNECT - GENERAL QUESTION";

				string body = "<b>From:</b> " + viewModel.FirstName + " " + viewModel.LastName + "<br /><br />";
				body += "<b>Email:</b> " + viewModel.Email + "<br /><br />";
				body += "<b>Question:</b> <br />" + viewModel.Comment;


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
				smtp.Send(mail);

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
