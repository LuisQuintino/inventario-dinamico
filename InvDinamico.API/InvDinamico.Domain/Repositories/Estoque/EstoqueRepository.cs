using api_domain.Config;
using InvDinamico.Domain.Repositories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InvDinamico.Domain.Repositories.Estoque
{
    public class EstoqueRepository(BdContext context, IHttpContextAccessor contextAccessor) : RepositoryBase<Entidades.Estoque>(context, contextAccessor), IEstoqueRepository
    {
        public void Inserir(Entidades.Estoque entidade) => Insert(entidade);

        public List<Entidades.Estoque> ListarEstoques() => Context.ToList();

        public Entidades.Estoque BuscarEstoque(Guid codigo) => Context.AsNoTracking().SingleOrDefault((x) => x.Codigo == codigo);

        public void AtualizarEstoque(Entidades.Estoque estoque) => Update(estoque);
    }
}
