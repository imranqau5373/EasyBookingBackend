using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities
{
    public class CompanySports : BaseEntity, IEntity
    {
        public long CompanyId { get; set; }
        public long SportsId { get; set; }
        public Company Company { get; set; }
        public Sports Sports { get; set; }
    }
}
