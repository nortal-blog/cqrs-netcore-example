using Microsoft.EntityFrameworkCore;

namespace netcore_docker.Domain
{
	public class DomainContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options) {
			options.UseSqlite("Data Source=products.db");
		}
	}
}