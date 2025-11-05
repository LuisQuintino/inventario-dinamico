using api_domain.Config;
using InvDinamico.Domain.Repositories.Base;
using Microsoft.AspNetCore.Http;

namespace InvDinamico.Domain.Repositories.AuditTrail
{
    public class AuditTrailRepository(BdContext bdContext, IHttpContextAccessor contextAccessor) : RepositoryBase<Entidades.AuditTrail>(bdContext, contextAccessor), IAuditTrailRepository
    {
        List<Entidades.AuditTrail> IAuditTrailRepository.ObterTodos() => Context.ToList();
    }
}
