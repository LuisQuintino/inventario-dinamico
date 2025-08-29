using api_domain.Config;
using InvDinamico.Domain.Entidades;
using InvDinamico.Domain.Entidades.Base;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace InvDinamico.Domain.Repositories.Base
{
    public abstract class RepositoryBase<T>(BdContext context) where T : EntityBase
    {
        public DbSet<T> Context { get; set; } = context.Set<T>();
        public DbSet<AuditTrail> AuditTrailContext = context.Set<AuditTrail>();

        public T? GetById(Guid id)
        {
            return Context.Find(id);
        }

        public T Insert(T entity)
        {
            if (entity.Codigo == null || entity.Codigo == Guid.Empty) 
                entity.Codigo = Guid.NewGuid();

            if (entity.Auditavel)
                InserirAudit(entity);

            var entityInserted = Context.Add(entity);
            context.SaveChanges();

            return entityInserted.Entity;
        }

        public T Update(T entity)
        {
            if (entity.Auditavel)
                InserirAudit(entity);

            var entityInserted = Context.Update(entity);
            context.SaveChanges();

            return entityInserted.Entity;
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
            context.SaveChanges();
        }

        private void InserirAudit(T entityAtualizada)
        {
            var entityDesatualizada = 
                Context.Find(entityAtualizada.Codigo);

            var entityAtualizadaSerializada = JsonSerializer.Serialize(entityAtualizada);

            string? entityDesatualizadaSerializada = string.Empty;
            if (entityDesatualizada != null)
                entityDesatualizadaSerializada = JsonSerializer.Serialize(entityDesatualizada);

            var nomeEntity = typeof(T).Name;
            var auditTrailEntity = new AuditTrail(entityDesatualizadaSerializada, entityAtualizadaSerializada, nomeEntity);

            AuditTrailContext.Add(auditTrailEntity);
        }
    }

}
