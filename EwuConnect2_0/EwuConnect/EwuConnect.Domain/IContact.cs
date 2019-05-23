using EwuConnect.Domain.Models.ContactViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain
{
	public interface IContact
	{
		bool sendMail(ContactViewModel viewModel);
	}
}
