namespace InvDinamico.Domain.Services.AuditTrail
{
    public interface IAuditTrailService
    {
        public IEnumerable<Entidades.AuditTrail> ObterAuditorias(string filtro);
    }
}
