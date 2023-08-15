﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;

public class EmailSender : IEmailSender
{
	public string SendGridSecret { get; set; }

	public EmailSender(IConfiguration _config)
	{
		SendGridSecret = Environment.GetEnvironmentVariable("SEND_GRID_SECRET_KEY") ?? "";
	}

	public Task SendEmailAsync(string email, string subject, string htmlMessage)
	{
		var emailToSend = new MimeMessage();
		emailToSend.From.Add(MailboxAddress.Parse("rombeldan@gmail.com"));
		emailToSend.To.Add(MailboxAddress.Parse(email));
		emailToSend.Subject = subject;
		emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

		////send email with GMAIL ACCOUNT
		//using (var emailClient = new SmtpClient())
		//{
		//    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
		//    emailClient.Authenticate("richfry@gmail.com", "Test123$");
		//    emailClient.Send(emailToSend);
		//    emailClient.Disconnect(true);
		//}

		//return Task.CompletedTask;

		var client = new SendGridClient(SendGridSecret);
		//THIS MUST MATCH A VERIFIED SENDGRID E-MAIL ADDRESS!!
		var from = new EmailAddress("rombeldan@gmail.com", "Cheaper By the Dozen");
		var to = new EmailAddress(email);
		var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
		return client.SendEmailAsync(msg);

	}
}