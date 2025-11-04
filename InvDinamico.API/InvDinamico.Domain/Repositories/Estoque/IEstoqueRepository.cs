namespace InvDinamico.Domain.Repositories.Estoque
{
    public interface IEstoqueRepository
    {
        void Inserir(Entidades.Estoque entidades);
        List<Entidades.Estoque> ListarEstoques();
    }
}
