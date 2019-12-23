using EasyBooking.Domain.Interfaces.Entity;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public virtual long Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        protected BaseEntity()
        {
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }

    }
}
