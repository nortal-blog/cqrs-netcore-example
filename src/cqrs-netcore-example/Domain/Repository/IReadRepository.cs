using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using netcore_docker.Domain;

namespace netcore_docker.Repositories
{
	public interface IReadRepository<TEntity> where TEntity : EntityBase
	{
		Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null);
		ValueTask<TEntity> GetById(Guid id);
	}
}