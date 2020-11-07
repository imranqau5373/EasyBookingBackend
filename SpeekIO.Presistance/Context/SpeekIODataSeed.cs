using EasyBooking.Domain.Entities.Bookings;
using EasyBooking.Domain.Entities.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeekIO.Presistence.Context
{
    internal class SpeekIODataSeed
    {
        private static object _syncRoot = new object();

        private SpeekIOContext _context;
        private static SpeekIODataSeed _instance;

        private SpeekIODataSeed(SpeekIOContext dbContext)
        {
            _context = dbContext;
        }

        public static SpeekIODataSeed Instance(SpeekIOContext context)
        {
            lock (_syncRoot)
            {
                if (null == _instance)
                    _instance = new SpeekIODataSeed(context);
                return _instance;
            }
        }

        public void SeedEverything(SpeekIOContext context)
        {
            // insert seeding logic & code here
            SeeDurationStatus(context);
            AddPackageDetails(context);
        }

        private void SeeDurationStatus(SpeekIOContext context)
        {
            if (!context.DurationStatus.Any())
            {
                var durationStatuses = new[]
                {
                    new DurationStatus {Name = "Published"},
                    new DurationStatus {Name = "Un-Published"}

                };
                context.DurationStatus.AddRange(durationStatuses);
                context.SaveChanges();
            }

        }

        private void AddPackageDetails(SpeekIOContext context)
        {
            if (!context.Package.Any())
            {
                var packages = new[]
                {
                    new Package {Name = "Free",Description = "it is avaliable for 10 days",Charges = 0,ExpiryDays = 10},
                    new Package {Name = "Basic",Description = "it is avaliable for 30 days",Charges = 10,ExpiryDays = 30},
                    new Package {Name = "Premium",Description = "it is avaliable for 365 days",Charges = 100,ExpiryDays = 365},

                };
                context.Package.AddRange(packages);
                context.SaveChanges();
            }

        }
    }
}
