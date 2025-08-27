using InvDinamico.Domain.Messaging.Operador;

namespace InvDinamico.Domain.Services.Operador
{
    public interface IOperadorService
    {
        void CadastrarOperador(CadastrarOperadorRequest cadastrarOperadorRequest);
    }
}
