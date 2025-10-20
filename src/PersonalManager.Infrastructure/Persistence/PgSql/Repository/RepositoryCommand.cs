using Microsoft.EntityFrameworkCore;
using PersonalManager.Infrastructure.Persistence.PgSql.Contexts;
using PersonaManager.Domain.Commons;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Repository
{
    public class RepositoryCommand<T> : IRepositoryCommand<T> where T : BaseEntity
    {
        private readonly PgSqlContext _db;
        public DbSet<T> dbSet { get; set; }
        public RepositoryCommand(PgSqlContext db, DbSet<T> dbSet)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            T? entity = await dbSet.FindAsync(id);
            return true;
        }

        public async Task<T> UpdateAsync(Guid? id, T entity, CancellationToken cancellationToken = default)
        {
            T? oldEntity = await dbSet.FindAsync([id], cancellationToken: cancellationToken);

            _db?.Entry(oldEntity).CurrentValues.SetValues(entity);
            return entity;
        }
    }
}