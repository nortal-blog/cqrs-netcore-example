using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using netcore_docker.Domain;
using netcore_docker.Domain.UnitOfWork;
using netcore_docker.Migrations;
using netcore_docker.Repositories;

namespace netcore_docker.Util
{
	public static class ServiceCollectionExt
	{
		public static void AddPersistence(this IServiceCollection services) {
			var domainContent = new DomainContext();
			DbConfig.Initialize(domainContent);

			services.AddSingleton<DbContext>(domainContent);
			services.AddSingleton<IWriteRepository<Product>, Repository<Product>>();
			services.AddSingleton<IReadRepository<Product>, Repository<Product>>();
			services.AddSingleton<IUnitOfWork, UnitOfWork>();
		}
	}
}