namespace InvDinamico.Domain.Repositories.AuditTrail
{
    public interface IAuditTrailRepository
    {
        public List<Entidades.AuditTrail> ObterTodos();
    }
}
