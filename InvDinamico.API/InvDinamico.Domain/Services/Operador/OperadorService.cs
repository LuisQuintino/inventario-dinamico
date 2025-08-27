using InvDinamico.Domain.Messaging.Operador;
using InvDinamico.Domain.Repositories.Operador;

namespace InvDinamico.Domain.Services.Operador
{
    public class OperadorService(IOperadorRepository operadorRepository) : IOperadorService
    {
        private readonly IOperadorRepository _operadorRepository = operadorRepository;

        public void CadastrarOperador(CadastrarOperadorRequest cadastrarOperadorRequest)
        {
            var operadorEntity = 
                new Entidades.Operador(cadastrarOperadorRequest);

            _operadorRepository.Inserir(operadorEntity);
        }
    }
}
