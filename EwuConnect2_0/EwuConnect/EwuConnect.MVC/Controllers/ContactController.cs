using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EwuConnect.Domain.Models.ContactViewModel;
using System.Net.Mail;
using System.Net;
using System.Web.UI;
using EwuConnect.Domain;

namespace EwuConnect.MVC.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContact contact_service;

		public ContactController(IContact contactService)
		{
			contact_service = contactService;
		}


	[HttpGet]
		public IActionResult Index()
		{
			return View(new ContactViewModel());
		}
		[HttpPost]
		public IActionResult Index(ContactViewModel viewModel)
		{
			if (ModelState.IsValid)
			{

				bool sent = contact_service.sendMail(viewModel);
				ModelState.Clear();
				return View(new ContactViewModel { isSent = sent });
									
			}
			
			return View(viewModel);
		}
	}
}