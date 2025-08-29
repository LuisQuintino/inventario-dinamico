using InvDinamico.Domain.Messaging.Base;

namespace InvDinamico.Domain.Messaging.Authentication
{
    public class AuthenticationResponse : ResponseBase
    {
        public string BearerToken { get; set; }
    }
}
