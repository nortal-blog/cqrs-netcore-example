using System;
using System.ComponentModel.DataAnnotations;

namespace netcore_docker.Domain
{
	public class EntityBase
	{
		[Key]
		public Guid Id { get; set; }
	}
}