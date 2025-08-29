using api_domain.Extensions;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Messaging.Operador;
using InvDinamico.Domain.Repositories.Operador;

namespace InvDinamico.Domain.Services.Operador
{
    public class OperadorService(IOperadorRepository operadorRepository) : IOperadorService
    {
        private readonly IOperadorRepository _operadorRepository = operadorRepository;

        public void AtualizarOperador(AtualizarOperadorRequest atualizarOperadorRequest, Guid codigoOperadorSolicitacao)
        {
            var operadorSolicitacao = 
                _operadorRepository.Obter(codigoOperadorSolicitacao)
                    ?? throw new InvDinamicoException("Operador da solicitação não encontrado.");

            var operadorAtualizado =
                _operadorRepository.Obter(atualizarOperadorRequest.CodigoOperador)
                    ?? throw new InvDinamicoException("Operador não encontrado.");

            if (operadorAtualizado.TipoOperador != atualizarOperadorRequest.TipoOperador)
            {
                if (operadorSolicitacao.TipoOperador == Entidades.Enums.TipoOperador.Administrador)
                    operadorAtualizado.TipoOperador = atualizarOperadorRequest.TipoOperador ?? operadorAtualizado.TipoOperador;
            }

            if(atualizarOperadorRequest.Situacao != null)
                if (operadorAtualizado.Situacao != atualizarOperadorRequest.Situacao && codigoOperadorSolicitacao == operadorAtualizado.Codigo)
                    throw new InvDinamicoException("Operador não pode atualizar sua própria situação");

            if (!string.IsNullOrWhiteSpace(atualizarOperadorRequest.Senha))
                operadorAtualizado.Senha = StringCipher.GenerateHash(atualizarOperadorRequest.Senha);

            operadorAtualizado.Situacao = atualizarOperadorRequest.Situacao ?? operadorAtualizado.Situacao;
            
            _operadorRepository.Atualizar(operadorAtualizado);
        }

        public void CadastrarOperador(CadastrarOperadorRequest cadastrarOperadorRequest)
        {
            var operadorEntity = 
                new Entidades.Operador(cadastrarOperadorRequest);

            _operadorRepository.Inserir(operadorEntity);
        }

        public IEnumerable<Entidades.Operador> ObterTodos() 
            => _operadorRepository.ObterTodos();
    }
}
