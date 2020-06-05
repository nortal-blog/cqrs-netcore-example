using Microsoft.EntityFrameworkCore;
using netcore_docker.Domain;

namespace netcore_docker.Migrations
{
	public class DbConfig
	{
		public static void Initialize(DomainContext context) {
			if (context.Database.IsSqlite()) context.Database.Migrate();
		}
	}
}