using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Interfaces;

namespace EasyBooking.Domain.Entities.Portfolio
{
    public class Package : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Charges { get; set; }
        public int ExpiryDays { get; set; }
        public bool isActive { get; set; }
    }
}
