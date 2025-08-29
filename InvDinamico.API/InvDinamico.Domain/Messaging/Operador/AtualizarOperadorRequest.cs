using InvDinamico.Domain.Entidades.Enums;

namespace InvDinamico.Domain.Messaging.Operador
{
    public class AtualizarOperadorRequest
    {
        public Guid CodigoOperador { get; set; }
        public string Senha { get; set; }
        public TipoOperador? TipoOperador { get; set; }
        public SituacaoOperador? Situacao { get; set; }
    }
}
