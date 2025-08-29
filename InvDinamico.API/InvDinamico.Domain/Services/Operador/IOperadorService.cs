using InvDinamico.Domain.Messaging.Operador;

namespace InvDinamico.Domain.Services.Operador
{
    public interface IOperadorService
    {
        void CadastrarOperador(CadastrarOperadorRequest cadastrarOperadorRequest);
        void AtualizarOperador(AtualizarOperadorRequest atualizarOperadorRequest, Guid codigoOperadorSolicitacao);
        IEnumerable<Entidades.Operador> ObterTodos();
    }
}
