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

		public ContactUsEmailModel(string name, string email, string message)
		{
			_name = name;
			_email = email;
			_message = message;
		}

		public string TemplateName => "ContactUs";

		public IList<IEmailRecipientPayloadInfo> Prepare()
		{
			IList<IEmailRecipientPayloadInfo> list = new List<IEmailRecipientPayloadInfo>();

			var payload = new Dictionary<string, object>();
			payload.Add("MessageSendEmail", _email);
			payload.Add("Message", _message);

			list.Add(new EmailRecipientPayloadInfo(new Recipient(_email, _message), Subject(), payload));

			return list;
		}

		private string Subject()
		{
			return $"Contact us message";
		}
	}
}
