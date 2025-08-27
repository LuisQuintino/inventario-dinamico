using api_domain.Config;
using InvDinamico.Domain.Entidades.Base;
using Microsoft.EntityFrameworkCore;

namespace InvDinamico.Domain.Repositories.Base
{
    public abstract class RepositoryBase<T>(BdContext context) where T : EntityBase
    {
        public DbSet<T> Context { get; set; } = context.Set<T>();

        public T? GetById(Guid id, bool nolock = true)
        {
            return Context.Find(id, nolock);
        }

        public T Insert(T entity)
        {
            if (entity.Codigo == null || entity.Codigo == Guid.Empty) 
                entity.Codigo = Guid.NewGuid();

            var entityInserted = Context.Add(entity);
            context.SaveChanges();

            return entityInserted.Entity;
        }

        public T Update(T entity)
        {
            var entityInserted = Context.Update(entity);
            context.SaveChanges();

            return entityInserted.Entity;
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
            context.SaveChanges();
        }
    }

}
