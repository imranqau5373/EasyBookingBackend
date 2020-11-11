using System;
using System.Collections.Generic;
using System.Text;
using EasyBooking.StripePayment.Implementation;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EasyBooking.Application.Interfaces.PaymentService;

namespace EasyBooking.StripePayment.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureStripePaymenService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStripePaymentService, StripPayment>();
            

            return services;
        }


    }
}
