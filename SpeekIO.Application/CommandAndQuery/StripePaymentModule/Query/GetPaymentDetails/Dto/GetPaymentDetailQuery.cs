﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.StripePaymentModule.Query.GetPaymentDetails.Dto
{
    public class GetPaymentDetailQuery : IRequest<GetPaymentDetailResponse>
    {
    }
}
