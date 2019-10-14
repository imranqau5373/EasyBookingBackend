using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Models.Email
{
    public class ForgetPasswordEmailModel : IEmailModel
    {
        private readonly string _name;
        private readonly string _email;
        private readonly string _resetPasswordUrl;

        public ForgetPasswordEmailModel(string name, string email, string resetPasswordUrl)
        {
            _name = name;
            _email = email;
            _resetPasswordUrl = resetPasswordUrl;
        }

        public string TemplateName => "ForgetPassword";

        public IList<IEmailRecipientPayloadInfo> Prepare()
        {
            IList<IEmailRecipientPayloadInfo> list = new List<IEmailRecipientPayloadInfo>();

            var payload = new Dictionary<string, object>();
            payload.Add("Name", _name);
            payload.Add("ResetLink", _resetPasswordUrl);

            list.Add(new EmailRecipientPayloadInfo(new Recipient(_name, _email), Subject(), payload));

            return list;
        }

        private string Subject()
        {
            return $"Reset password for your account";
        }
    }
}
