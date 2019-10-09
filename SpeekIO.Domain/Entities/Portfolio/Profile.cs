using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Portfolio
{
    public class Profile : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Timezone { get; set; }
        public bool OptInNewsletter { get; set; }

        public ApplicationUser User { get; set; }

        public virtual Company Company { get; set; }
        public virtual long? CompanyId { get; set; }
    }
}
