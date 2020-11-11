using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.Interfaces.PaymentService
{
    public interface IStripePaymentService
    {

        bool AddPayment();

    }
}
