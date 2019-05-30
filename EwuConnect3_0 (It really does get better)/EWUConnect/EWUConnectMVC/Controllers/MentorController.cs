using Microsoft.AspNetCore.Mvc;
using EwuConnect.Domain.Models.MentorViewModel;
using EwuConnect.Domain;

namespace EwuConnect.MVC.Controllers
{

		
	public class MentorController : Controller
	{
		private readonly IEmailSender email_service;

		public MentorController(IEmailSender emailservice)
		{
			email_service = emailservice;
		}


		[HttpGet]
		public IActionResult BecomeMentor()
		{
			return View(new MentorViewModel());
		}
		[HttpPost]
		public IActionResult BecomeMentor(MentorViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var subject = "EWU CONNECT - GENERAL QUESTION";

				string body = "<b>From:</b> " + viewModel.FirstName + " " + viewModel.LastName + "<br /><br />";
				body += "<b>Email:</b> " + viewModel.Email + "<br /><br />";
				body += "<b>Phone:</b>" + " (" + viewModel.AreaCode + ") - " + viewModel.FirstPhone + " - " + viewModel.LastPhone + "<br /><br />";
				body += "<b>Company/University:</b> " + viewModel.Association + "<br /><br />";
				body += "<b>Major:</b> " + viewModel.Major + "<br /><br />";
				body += "<b>Graduated:</b> " + viewModel.Graduated + "<br /><br />";
				body += "<b>Message:</b> <br />" + viewModel.Comment;

				bool sent = email_service.SendEmailAsync(viewModel.Email, subject, body).Result;
				ModelState.Clear();
				return View(new MentorViewModel { isSent = sent });

			}

			return View(viewModel);
		}
	}

}

