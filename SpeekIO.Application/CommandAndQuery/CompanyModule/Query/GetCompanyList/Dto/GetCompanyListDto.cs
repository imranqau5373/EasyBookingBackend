using System;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto
{
    public class GetCompanyListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string SubDomainPrefix { get; set; }
        public int SportsCount { get; set; }
        public int CourtsCount { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }

        public bool? IsDeletedCourt { get; set; }
        public long? PackageId { get; set; }
        //should include the list for relevant Sports and Courts ?
    }
}
