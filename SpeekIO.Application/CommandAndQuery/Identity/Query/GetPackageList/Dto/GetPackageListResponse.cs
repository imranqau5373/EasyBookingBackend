using SpeekIO.Domain.ViewModels.Response;
using System.Collections.Generic;

namespace EasyBooking.Application.CommandAndQuery.Identity.Query.GetPackageList.Dto
{
	public class GetPackageListResponse : CommonResponse
	{
		public List<GetPackageListModel> PackageList { get; set; }
	}

	public class GetPackageListModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Charges { get; set; }
		public int ExpiryDays { get; set; }
		public bool isActive { get; set; }
	}
}
