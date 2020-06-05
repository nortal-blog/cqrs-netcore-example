using System.Threading.Tasks;
using netcore_docker.Repositories;

namespace netcore_docker.Domain.UnitOfWork
{
	public interface IUnitOfWork
	{
		IWriteRepository<Product> ProductRepository { get; }
		Task<int> CommitAsync();
	}
}