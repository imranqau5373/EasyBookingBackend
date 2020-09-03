using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Models.Email
{
    public class SignupEmailModel : IEmailModel
    {
        private readonly string _companyName;
        private readonly string _adminEmail;
        private readonly IRecipient _recipient;

        public SignupEmailModel(IRecipient recipient,string CompanyName,string AdminEmail)
        {
            this._recipient = recipient;
            this._companyName = CompanyName;
            this._adminEmail = AdminEmail;
        }

        public string TemplateName { get; set; } = "SignupThankYou";

        public IList<IEmailRecipientPayloadInfo> Prepare()
        {
            IList<IEmailRecipientPayloadInfo> list = new List<IEmailRecipientPayloadInfo>();

            var payload = new Dictionary<string, object>();
            payload.Add("CompanyName", _companyName);
            payload.Add("AdminEmail", _adminEmail);


            list.Add(new EmailRecipientPayloadInfo(_recipient, Subject(), payload));

            return list;
        }

        private string Subject()
        {
            return "Company Created Successfully";
        }
    }
}
