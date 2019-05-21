using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EWUConnectMVC.Models.Contact;
using System.Net.Mail;
using System.Net;

namespace EWUConnectMVC.Controllers
{
	public class ContactController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View(new ContactViewModel
			{
				FirstName = "",
				LastName = "",
				Email = "",
				Comment = ""
			});
		}
		[HttpPost]
		public IActionResult Index(ContactViewModel viewModel)
		{
			sendMail(viewModel);
			return View();
		}
		private void sendMail(ContactViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					MailMessage message = new MailMessage();
					message.From = new MailAddress(viewModel.Email);//Email which you are getting 
																	//from contact us page 
					message.To.Add("connectewu@gmail.com");//Where mail will be sent 
					message.Subject = "EWU CONNECT - GENERAL QUESTION";
					string body = "<b>From:</b> " + viewModel.FirstName + " " + viewModel.LastName + "<br /><br />";
					body += "<b>Email:</b> " + viewModel.Email + "<br /><br />";
					body += "<b>Question:</b> <br />" + viewModel.Comment;

					const string fromAddress = "connectewu@gmail.com";
					const string fromPassword = "Nate Bryant";

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

					ViewBag.Message = $"success";
				}
				catch (Exception ex)
				{
					ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
				}
			}
			ViewBag.Message = $"error";
		}
		public IActionResult Error()
		{
			return View();
		}
	}
}