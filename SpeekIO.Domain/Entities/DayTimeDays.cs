using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities
{
    public class DayTimeDays : BaseEntity, IEntity
    {
        public DayTimeDays()
        {

        }

        public int Day { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public long DayTimeScheduleId { get; set; }

        public virtual DayTimeSchedule DayTimeSchedule { get; set; }
    }
}
