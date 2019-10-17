using MediatR;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
using SpeekIO.Domain.ViewModels.Response.UmbracoResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Umbraco.ContactUs
{
	public class ContactUsCommandHandler : IRequestHandler<ContactUsCommand, ContactUsResponse>
	{

		private ISpeekIODbContext _context;
		private readonly AutoMapper.IMapper _mapper;
		private IEmailService _emailService;
		public ContactUsCommandHandler(AutoMapper.IMapper mapper, ISpeekIODbContext context,IEmailService emailService)
		{
			_mapper = mapper;
			_context = context;
			_emailService = emailService;
		}
		public async Task<ContactUsResponse> Handle(ContactUsCommand request, CancellationToken cancellationToken)
		{

			return await SaveContactUs(request);
		}

		private async Task<ContactUsResponse> SaveContactUs(ContactUsCommand request)
		{

			//Map request user to contactus user.
			var contactUs = _mapper.Map<Domain.Entities.UmbracoEntities.ContactUs>(request);
			_context.ContactUs.Add(contactUs);
			await _context.SaveChangesAsync();
			await SendContactUsMessage(contactUs);
			return new ContactUsResponse
			{
				Successful = true,
				Message = "Message sent successfully."
			};
		}

		private async Task SendContactUsMessage(Domain.Entities.UmbracoEntities.ContactUs contactUs)
		{
			var contactUsMessage = contactUs.Message;
			IRecipient recipient = new Recipient(contactUs.Email, "imranqau5373@gmail.com");
			IEmailModel emailModel = new ContactUsEmailModel(contactUs.Name, contactUs.Email, contactUs.Message);

			await _emailService.SendEmailAsync(emailModel);
		}


	}
}
