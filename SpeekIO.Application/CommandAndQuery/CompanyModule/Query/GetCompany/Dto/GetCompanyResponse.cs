using SpeekIO.Domain.ViewModels.Response;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompany.Dto
{
    public class GetCompanyResponse : CommonResponse
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string SubDomainPrefix { get; set; }
        public long? PackageId { get; set; }
        // public ICollection<Sports> Sport { get; set; }
        // public ICollection<Courts> Court { get; set; }
    }
}
