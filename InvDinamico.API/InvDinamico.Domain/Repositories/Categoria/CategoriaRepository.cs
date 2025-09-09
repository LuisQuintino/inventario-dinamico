using api_domain.Config;
using InvDinamico.Domain.Repositories.Base;

namespace InvDinamico.Domain.Repositories.Categoria
{
    public class CategoriaRepository(BdContext context) : RepositoryBase<Entidades.Categoria>(context), ICategoriaRepository
    {
    }
}
