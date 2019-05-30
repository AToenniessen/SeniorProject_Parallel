using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EwuConnect.Domain.Models.ContactViewModel;
using System.Net.Mail;
using System.Net;
using EwuConnect.Domain;

namespace EwuConnect.MVC.Controllers
{
	public class ContactController : Controller
	{
		private readonly IEmailSender email_service;

		public ContactController(IEmailSender emailService)
		{
			email_service = emailService;
		}


		[HttpGet]
		public IActionResult ContactUs()
		{
			return View(new ContactViewModel());
		}
		[HttpPost]
		public IActionResult ContactUs(ContactViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var subject = "EWU CONNECT - GENERAL QUESTION";

				string body = "<b>From:</b> " + viewModel.FirstName + " " + viewModel.LastName + "<br /><br />";
				body += "<b>Email:</b> " + viewModel.Email + "<br /><br />";
				body += "<b>Question:</b> <br />" + viewModel.Comment;

				bool sent = email_service.SendEmailAsync(viewModel.Email, subject, body).Result;
				ModelState.Clear();
				return View(new ContactViewModel { isSent = sent });
									
			}
			
			return View(viewModel);
		}
	}
}