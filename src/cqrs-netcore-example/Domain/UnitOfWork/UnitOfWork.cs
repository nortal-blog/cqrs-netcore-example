using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using netcore_docker.Repositories;

namespace netcore_docker.Domain.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DbContext domainContext;

		public UnitOfWork(DbContext domainContext, IWriteRepository<Product> productRepository) {
			this.domainContext = domainContext;
			ProductRepository = productRepository;
		}

		public IWriteRepository<Product> ProductRepository { get; }

		public Task<int> CommitAsync() {
			return domainContext.SaveChangesAsync();
		}
	}
}