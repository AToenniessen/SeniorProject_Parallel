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
			MailMessage message = new MailMessage();
			try
			{
				const string fromAddress = "ewuconnect@gmail.com";
				const string fromPassword = "Nate Bryant";
				message.From = new MailAddress(fromAddress);        //swap from and to later. proof of concept applied
				message.To.Add(new MailAddress(viewModel.Email));

				message.Subject = "EWU CONNECT - GENERAL QUESTION";

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

				message.IsBodyHtml = true;
				message.Body = body;
				smtp.Send(message);

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
