using api_domain.Config;
using InvDinamico.Domain.Repositories.Base;
using Microsoft.AspNetCore.Http;

namespace InvDinamico.Domain.Repositories.Movimento
{
    public class MovimentoRepository(BdContext context, IHttpContextAccessor contextAccessor) : RepositoryBase<Entidades.Movimento>(context, contextAccessor), IMovimentoRepository
    {
        public void Inserir(Entidades.Movimento movimento) => Insert(movimento);
    }
}
