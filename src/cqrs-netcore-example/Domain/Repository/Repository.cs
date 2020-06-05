using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using netcore_docker.Domain;

namespace netcore_docker.Repositories
{
	public class Repository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity> where TEntity : EntityBase
	{
		private readonly DbSet<TEntity> dbSet;

		public Repository(DbContext context) {
			dbSet = context.Set<TEntity>();
		}

		public ValueTask<TEntity> GetById(Guid id) {
			return dbSet.FindAsync(id);
		}

		public ValueTask<EntityEntry<TEntity>> Add(TEntity source) {
			return dbSet.AddAsync(source);
		}

		public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null) {
			var query = predicate == null ? dbSet.Where(p => true) : dbSet.Where(predicate);

			return await query.ToArrayAsync();
		}
	}
}