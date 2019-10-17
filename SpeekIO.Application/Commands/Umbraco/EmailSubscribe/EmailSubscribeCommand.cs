using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Domain.ViewModels.Response.UmbracoResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Umbraco
{
	public class EmailSubscribeCommand : IRequest<EmailSubscriptionResponse>
	{

		public string EmailAddress { get; set; }

		public bool isSubscribed { get; set; }
	}
}
