using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Interfaces.Entity
{
	public interface IGeneral
	{
		string Name { get; set; }

		string Description { get; set; }
	}
}
