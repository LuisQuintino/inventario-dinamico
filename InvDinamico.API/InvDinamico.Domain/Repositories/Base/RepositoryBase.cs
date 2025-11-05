using api_domain.Config;
using InvDinamico.Domain.Entidades;
using InvDinamico.Domain.Entidades.Base;
using InvDinamico.Domain.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using ZstdSharp.Unsafe;

namespace InvDinamico.Domain.Repositories.Base
{
    public abstract class RepositoryBase<T>(BdContext context, IHttpContextAccessor httpContextAccessor) where T : EntityBase
    {
        public DbSet<T> Context { get; set; } = context.Set<T>();
        public DbSet<Entidades.AuditTrail> AuditTrailContext = context.Set<Entidades.AuditTrail>();
        public DbSet<Entidades.Operador> OperadorContext = context.Set<Entidades.Operador>();

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
                Context.AsNoTracking().SingleOrDefault(e => e.Codigo == entityAtualizada.Codigo);

            var operadorAcao = OperadorContext.Find(ObterCodigoOperador());
            var entityAtualizadaSerializada = JsonSerializer.Serialize(entityAtualizada);

            string? entityDesatualizadaSerializada = string.Empty;
            if (entityDesatualizada != null)
                entityDesatualizadaSerializada = JsonSerializer.Serialize(entityDesatualizada);

            var nomeEntity = typeof(T).Name;
            var auditTrailEntity = new Entidades.AuditTrail(entityDesatualizadaSerializada, entityAtualizadaSerializada, nomeEntity, operadorAcao);

            AuditTrailContext.Add(auditTrailEntity);
        }

        public Guid ObterCodigoOperador()
        {
            var httpContext = httpContextAccessor.HttpContext;
            var codigoUsuario = httpContext.User.Claims
                .SingleOrDefault(x => x.Type == "CodigoOperador")?.Value;

            if (codigoUsuario.IsNullOrEmpty())
                return Guid.Empty;

            return Guid.Parse(codigoUsuario);
        }
    }

}
