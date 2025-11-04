using api_domain.Extensions;
using api_domain.Messaging.Authentication;
using InvDinamico.Domain.Messaging.Authentication;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Repositories.Operador;

namespace InvDinamico.Domain.Services.Autenticacao
{
    public class AutenticacaoService(IOperadorRepository operadorRepository) : IAutenticacaoService
    {
        private readonly IOperadorRepository _operadorRepository = operadorRepository;

        public AuthenticationResponse Autenticar(AuthenticationDTO authenticationDTO)
        {
            var operador = 
                _operadorRepository.Obter(email: authenticationDTO.Email)
                    ?? throw new InvDinamicoException("Email ou Senha inválidos.");

            if (StringCipher.CompareHash(operador.Senha, authenticationDTO.Senha))
                return new AuthenticationResponse
                {
                    Sucesso = true,
                    BearerToken = JwtExtensions.GerarToken(operador),
                    Operador = new {
                        operador.Email,
                        operador.Codigo,
                        operador.TipoOperador
                    }
                };

            throw new InvDinamicoException("Email ou Senha inválidos.");
        }
    }
}
