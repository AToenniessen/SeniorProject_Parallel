using System;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

namespace EWUConnectMVC.Controllers
{
	public partial class MentorController
	{

			protected void Page_Load(object sender, EventArgs e)
			{

				if (Request.QueryString["source"] != null && Request.QueryString["source"].Equals("contactSubmit"))
				{
					AlertSuccess.Attributes["class"] = "alert alert-success alert-dismissible";
					AlertDanger.Attributes["class"] = "alert alert-danger alert-dismissible collapse";
				}
			}

			protected void BtnMentor_Click(object sender, EventArgs e)
			{
				//.Transfer("Mentor.aspx");
			}

			protected void BtnSubmit_Click(object sender, EventArgs e)
			{
				if (!Page.IsValid)
				{
					AlertDanger.Attributes["class"] = "alert alert-danger alert-dismissible";
					AlertSuccess.Attributes["class"] = "alert alert-success alert-dismissible collapse";

					if (!RequiredName.IsValid)
					{
						FirstName.Attributes["Placeholder"] = "* First Name";
					}
					if (!RequiredName.IsValid)
					{
						LastName.Attributes["Placeholder"] = "* Last Name";
					}
					if (!RequiredEmail.IsValid)
					{
						Email.Attributes["Placeholder"] = "* Email";
					}
					if (!RequiredComment.IsValid)
					{
						Comments.Attributes["Placeholder"] = "* Message";
					}

					return;
				}
				else
				{
					try
					{
						SendMail();

						Response.Redirect(Request.Url.AbsoluteUri + "?source=contactSubmit");
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex);
						//Comments.Text = ex.ToString();
					}
				}
			}

			protected void SendMail()
			{
				MailMessage mail = new MailMessage();
				const string fromAddress = "connectewu@gmail.com";
				mail.From = new MailAddress(fromAddress);
				mail.To.Add(new MailAddress(Email.Text));
				const string fromPassword = "Nate Bryant";

				mail.Subject = "EWU CONNECT - GENERAL QUESTION";

				string body = "<b>From:</b> " + FirstName.Text + " " + LastName.Text + "<br /><br />";
				body += "<b>Email:</b> " + Email.Text + "<br /><br />";
				body += "<b>Question:</b> <br />" + Comments.Text;

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
			}
		}
	
}
