namespace InvDinamico.Domain.Repositories.Estoque
{
    public interface IEstoqueRepository
    {
        void Inserir(Entidades.Estoque entidades);
        List<Entidades.Estoque> ListarEstoques();
        Entidades.Estoque BuscarEstoque(Guid codigo);
        void AtualizarEstoque(Entidades.Estoque estoque);
    }
}
