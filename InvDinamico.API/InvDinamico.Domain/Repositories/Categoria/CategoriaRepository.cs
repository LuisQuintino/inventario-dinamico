using api_domain.Config;
using InvDinamico.Domain.Repositories.Base;

namespace InvDinamico.Domain.Repositories.Categoria
{
    public class CategoriaRepository(BdContext context) : RepositoryBase<Entidades.Categoria>(context), ICategoriaRepository
    {
        public void Atualizar(Entidades.Categoria entidade) => Update(entidade);

        public void Inserir(Entidades.Categoria entidade) => Insert(entidade);

        public Entidades.Categoria Obter(Guid codigoCategoria) => GetById(codigoCategoria);
        public List<Entidades.Categoria> ListarCategorias() => Context.ToList();
    }
}
