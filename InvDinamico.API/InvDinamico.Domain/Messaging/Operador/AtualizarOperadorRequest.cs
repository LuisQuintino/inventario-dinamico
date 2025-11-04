using InvDinamico.Domain.Entidades.Enums;

namespace InvDinamico.Domain.Messaging.Operador
{
    public class AtualizarOperadorRequest
    {
        public Guid Codigo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoOperador? TipoOperador { get; set; }
        public SituacaoOperador? Situacao { get; set; }
    }
}
