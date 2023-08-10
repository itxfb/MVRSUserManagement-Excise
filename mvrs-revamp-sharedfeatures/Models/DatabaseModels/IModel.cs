using System;

namespace Models.DatabaseModels
{
	public interface IModel
	{
		DateTime CreatedAt { get; set; }
		long CreatedBy { get; set; }
	}
}