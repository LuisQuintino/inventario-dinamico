using InvDinamico.Domain.Messaging.Estoque;

namespace InvDinamico.Domain.Services.Estoque
{
    public interface IEstoqueService
    {
        void InserirNovoEstoque(InserirEstoqueRequest request, Guid codigoOperador);
        List<Entidades.Estoque> ListarEstoques();
    }
}
