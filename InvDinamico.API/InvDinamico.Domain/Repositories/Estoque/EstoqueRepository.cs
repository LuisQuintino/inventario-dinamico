using api_domain.Config;
using InvDinamico.Domain.Repositories.Base;

namespace InvDinamico.Domain.Repositories.Estoque
{
    public class EstoqueRepository(BdContext context) : RepositoryBase<Entidades.Estoque>(context), IEstoqueRepository
    {
        public void Inserir(Entidades.Estoque entidade) => Insert(entidade);

        public List<Entidades.Estoque> ListarEstoques() => Context.ToList();
    }
}
