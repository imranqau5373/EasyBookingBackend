using MediatR;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.UpdateCompany.Dto
{
    public class UpdateCompanyCommand : IRequest<UpdateCompanyResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string SubDomainPrefix { get; set; }
        public long? PackageId { get; set; }
    }
}
