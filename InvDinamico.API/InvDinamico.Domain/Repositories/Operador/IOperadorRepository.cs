namespace InvDinamico.Domain.Repositories.Operador
{
    public interface IOperadorRepository
    {
        Entidades.Operador Inserir(Entidades.Operador operadorEntity);
        Entidades.Operador Atualizar(Entidades.Operador operadorEntity);
        void Remover(Entidades.Operador operadorEntity);
        Entidades.Operador? Obter(Guid codigo);
        Entidades.Operador? Obter(string email);
        IEnumerable<Entidades.Operador> ObterTodos();
    }
}
