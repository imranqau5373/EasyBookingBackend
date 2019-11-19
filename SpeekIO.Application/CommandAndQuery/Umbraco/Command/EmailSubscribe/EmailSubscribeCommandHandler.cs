using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.UmbracoEntities;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Domain.ViewModels.Response.UmbracoResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Umbraco
{
	public class EmailSubscribeCommandHandler : IRequestHandler<EmailSubscribeCommand, EmailSubscriptionResponse>
	{
		private ISpeekIODbContext _context;
		private readonly AutoMapper.IMapper _mapper;
		public EmailSubscribeCommandHandler(AutoMapper.IMapper mapper,ISpeekIODbContext context)
		{
			_mapper = mapper;
			_context = context;
		}


		public async Task<EmailSubscriptionResponse> Handle(EmailSubscribeCommand request, CancellationToken cancellationToken)
		{
			//Map request user to domain user.
			var userSubscription = _mapper.Map<Domain.Entities.UmbracoEntities.SubscribeEmail>(request);

			//check user is already subscibed or not.
			var subscribedUser = await GetUserSubscription(userSubscription.EmailAddress);
			if(subscribedUser == null)
			{
				//Add user Subscription.
				return await CreateUserSubscription(userSubscription);
			}
			else
			{
				if (subscribedUser.isSubscribed)
				{
					return new EmailSubscriptionResponse
					{
						Successful = true,
						Message = "User already subscribed."
					};
				}
				else
				{
					//User email is added but unsubscribed. update with subscribed.
					return await UpdateUserSubscription(userSubscription);
				}
			}

		}

		private async Task<SubscribeEmail> GetUserSubscription(string email)
		{
			return await _context.SubscribeEmails.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
		}

		private async Task<EmailSubscriptionResponse> CreateUserSubscription(SubscribeEmail userSubscription)
		{
			_context.SubscribeEmails.Add(userSubscription);
			await _context.SaveChangesAsync();

			return new EmailSubscriptionResponse
			{
				Successful = true,
				Message = "User subscribe successfully."
			};
		}

		private async Task<EmailSubscriptionResponse> UpdateUserSubscription(SubscribeEmail userSubscription)
		{
			userSubscription.isSubscribed = true;
			userSubscription.ModifiedOn = System.DateTime.Now;
			_context.SubscribeEmails.Update(userSubscription);
			await _context.SaveChangesAsync();
			return new EmailSubscriptionResponse
			{
				Successful = true,
				Message = "User subscribe successfully."
			};
		}
	}
}
