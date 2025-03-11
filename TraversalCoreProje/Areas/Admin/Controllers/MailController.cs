using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(MailRequest mailRequest)
		{
		
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traversal5353@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);
			MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);
			
			var bodyBuilder=new BodyBuilder();
			bodyBuilder.TextBody =mailRequest.Body;
			mimeMessage.Body=bodyBuilder.ToMessageBody();

			mimeMessage.Subject = mailRequest.Subject;

			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Connect("smtp.gmail.com", 587, false);
			smtpClient.Authenticate("traversal5353@gmail.com", "myyu iqcx lxqb bipn");
			smtpClient.Send(mimeMessage);
			smtpClient.Disconnect(true);
			return View();
		}
	}
}
