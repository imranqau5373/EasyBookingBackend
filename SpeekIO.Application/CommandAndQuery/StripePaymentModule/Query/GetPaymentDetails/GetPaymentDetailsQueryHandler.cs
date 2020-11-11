using EasyBooking.Application.CommandAndQuery.StripePaymentModule.Query.GetPaymentDetails.Dto;
using EasyBooking.Application.Interfaces.PaymentService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.StripePaymentModule.Query.GetPaymentDetails
{
	public class GetPaymentDetailsQueryHandler : CommandHandlerBase<GetPaymentDetailQuery, GetPaymentDetailResponse>
	{

		private readonly ILogger<GetPaymentDetailQuery> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;
		private readonly IStripePaymentService _stripe;

		public GetPaymentDetailsQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IStripePaymentService stripeService,
			ILogger<GetPaymentDetailQuery> logger, AutoMapper.IMapper mapper, SpeekIOContext context) : base(userManager, httpContextAccessor)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._stripe = stripeService;

		}

		public override Task<GetPaymentDetailResponse> Handle(GetPaymentDetailQuery request, CancellationToken cancellationToken)
		{
			var value = this._stripe.AddPayment();
			throw new NotImplementedException();
		}
	}
}
