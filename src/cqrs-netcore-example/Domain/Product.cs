using System.ComponentModel.DataAnnotations;

namespace netcore_docker.Domain
{
	public class Product : EntityBase
	{

		[MaxLength(20)]
		public string Code { get; set; }

		[MaxLength(500)]
		public string Description { get; set; }
	}
}