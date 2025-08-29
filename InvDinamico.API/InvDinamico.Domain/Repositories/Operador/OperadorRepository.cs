using api_domain.Config;
using InvDinamico.Domain.Repositories.Base;

namespace InvDinamico.Domain.Repositories.Operador
{
    public class OperadorRepository(BdContext context) : RepositoryBase<Entidades.Operador>(context), IOperadorRepository
    {
        public Entidades.Operador Atualizar(Entidades.Operador operadorEntity) => Update(operadorEntity);

        public Entidades.Operador Inserir(Entidades.Operador operadorEntity) => Insert(operadorEntity);

        public Entidades.Operador? Obter(Guid codigo) => GetById(codigo);

        public void Remover(Entidades.Operador operadorEntity) => Delete(operadorEntity);

        public Entidades.Operador? Obter(string email)
            => Context.Where((op) => op.Email == email)?.SingleOrDefault();

        public IEnumerable<Entidades.Operador> ObterTodos()
            => Context.ToList();
    }
}
