using InvDinamico.Domain.Entidades.Enums;

namespace InvDinamico.Domain.Messaging.Operador
{
    public class CadastrarOperadorRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoOperador TipoOperador { get; set; }
    }
}
