using api_domain.Messaging.Authentication;
using InvDinamico.Domain.Messaging.Authentication;

namespace InvDinamico.Domain.Services.Autenticacao
{
    public interface IAutenticacaoService
    {
        AuthenticationResponse Autenticar(AuthenticationDTO authenticationDTO);
    }
}
