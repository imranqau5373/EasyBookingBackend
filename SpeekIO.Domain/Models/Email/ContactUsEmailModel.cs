using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Models.Email
{
	public class ContactUsEmailModel : IEmailModel
	{

		private readonly string _name;
		private readonly string _email;
		private readonly string _message;
		private readonly IRecipient _recipient;

		public ContactUsEmailModel(string name, string email, string message, IRecipient recipient)
		{
			_name = name;
			_email = email;
			_message = message;
			_recipient = recipient;
		}

		public string TemplateName { get; set; } = "ContactUs";

		public IList<IEmailRecipientPayloadInfo> Prepare()
		{
			IList<IEmailRecipientPayloadInfo> list = new List<IEmailRecipientPayloadInfo>();

			var payload = new Dictionary<string, object>();
			payload.Add("MessageSendEmail", _email);
			payload.Add("Message", _message);
			payload.Add("Name", _name);
			list.Add(new EmailRecipientPayloadInfo(new Recipient(_name, _recipient.Email), Subject(), payload));

			return list;
		}

		private string Subject()
		{
			return $"Contact us message";
		}
	}
}
