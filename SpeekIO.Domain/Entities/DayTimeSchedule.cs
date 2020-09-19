using SpeekIO.Domain.Entities;
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

        }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
