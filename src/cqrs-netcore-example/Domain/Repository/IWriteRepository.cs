using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using netcore_docker.Domain;

namespace netcore_docker.Repositories
{
	public interface IWriteRepository<TEntity> : IReadRepository<TEntity> where TEntity : EntityBase
	{
		ValueTask<EntityEntry<TEntity>> Add(TEntity source);
	}
}