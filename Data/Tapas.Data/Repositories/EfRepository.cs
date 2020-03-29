namespace Tapas.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Tapas.Data.Common.Repositories;

    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public EfRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected ApplicationDbContext Context { get; set; }

        protected DbSet<TEntity> DbSet { get; set; }

        public virtual IQueryable<TEntity> All() => this.Context.Set<TEntity>();

        public virtual IQueryable<TEntity> AllAsNoTracking() => this.Context.Set<TEntity>().AsNoTracking();

        public async virtual Task AddAsync(TEntity entity) => await this.Context.Set<TEntity>().AddAsync(entity).AsTask();

        public async Task AddEntityAsync(TEntity entity)
        {
            await this.Context.AddAsync<TEntity>(entity);
            this.Context.SaveChanges();
        }

        public virtual int SaveChanges() => this.Context.SaveChanges();

        public virtual void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Context.Set<TEntity>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity) => this.Context.Set<TEntity>().Remove(entity);

        public virtual Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
