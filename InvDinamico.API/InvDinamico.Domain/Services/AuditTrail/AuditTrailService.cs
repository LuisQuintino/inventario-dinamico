using InvDinamico.Domain.Extensions;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Repositories.AuditTrail;

namespace InvDinamico.Domain.Services.AuditTrail
{
    public class AuditTrailService(IAuditTrailRepository auditTrailRepository) : IAuditTrailService
    {
        private readonly IAuditTrailRepository _auditTrailRepository = auditTrailRepository;

        public IEnumerable<Entidades.AuditTrail> ObterAuditorias(string filtro)
        {
            var auditorias = _auditTrailRepository.ObterTodos()
                ?? throw new InvDinamicoException("Nenhuma auditoria encontrada.");

            if (auditorias.Any() && !filtro.IsNullOrEmpty())
                return AplicarFiltro(auditorias, filtro);

            return auditorias;
        }

        public IEnumerable<Entidades.AuditTrail> AplicarFiltro(IEnumerable<Entidades.AuditTrail> lista, string filtro)
            => lista.Where((x) => !x.NomeEntidade.IsNullOrEmpty() ?
                x.NomeEntidade.Normalizar().Contains(filtro.Normalizar()) : false);
    }
}
