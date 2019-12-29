using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Command.AddProfile.Dto
{
    public class AddProfileCommand : IRequest<AddProfileResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Timezone { get; set; }
        public bool OptInNewsletter { get; set; }
        public string PictureUrl { get; set; }
        public string PictureThumbnailUrl { get; set; }
        public virtual long? CompanyId { get; set; }
    }
}
