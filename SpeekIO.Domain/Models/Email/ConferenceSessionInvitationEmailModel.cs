
using SpeekIO.Common.Extensions;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Models.Email
{
    public class ConferenceSessionInvitationEmailModel : IEmailModel
    {
        public List<string> Emails { get; set; } = new List<string>();
        public string ConferenceTitle { get; set; }
        public long ConferenceId { get; set; }
        public string domain { get; set; }
        public string ScheduledOn { get; set; }
        public string Duration { get; set; }
        public string ScheduledBy { get; set; }

        public ConferenceSessionInvitationEmailModel()
        {
        }
        public string TemplateName => "ConferenceSessionInvitation";


        public IList<IEmailRecipientPayloadInfo> Prepare()
        {
            var response = new List<IEmailRecipientPayloadInfo>();
            foreach (var email in Emails)
            {
                var payload = new Dictionary<string, object>();

                payload["Title"] = ConferenceTitle;
                payload["Link"] = CreateConferenceLink(email);
                payload["ScheduledBy"] = ScheduledBy;
                payload["Duration"] = Duration;

                var payloadInfo = new EmailRecipientPayloadInfo(new Recipient(string.Empty, email), payload);

                response.Add(payloadInfo);
            }

            return response;
        }

        private string CreateConferenceLink(string email)
        {
            string tokenInformation = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Email = email,
                ConferenceId = ConferenceId
            }, Newtonsoft.Json.Formatting.None);

            string connectionToken = tokenInformation.Encrypt();

            var url = $"{domain}/api/Conference/Connect?connecttoken={connectionToken}";

            return System.Web.HttpUtility.UrlEncode(url);
        }
    }
}
