using api_domain.Config;
using InvDinamico.Domain.Repositories.Base;

namespace InvDinamico.Domain.Repositories.Movimento
{
    public class MovimentoRepository(BdContext context) : RepositoryBase<Entidades.Movimento>(context), IMovimentoRepository
    {
    }
}
