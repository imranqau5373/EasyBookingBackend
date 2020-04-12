using EasyBooking.Domain.Entities.Bookings;
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
    }
}
