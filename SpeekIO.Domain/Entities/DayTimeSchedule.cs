using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities
{
    public class DayTimeSchedule : BaseEntity, IEntity
    {

        public DayTimeSchedule()
        {
            DayTimeDays = new HashSet<DayTimeDays>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public long? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public ICollection<DayTimeDays> DayTimeDays { get; set; }

    }
}
