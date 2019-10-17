using MediatR;
using SpeekIO.Domain.ViewModels.Response.UmbracoResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Umbraco.ContactUs
{
	public class ContactUsCommand : IRequest<ContactUsResponse>
	{
		public string CompanyName { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Message { get; set; }
	}
}
