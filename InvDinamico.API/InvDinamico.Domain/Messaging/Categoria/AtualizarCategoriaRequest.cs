using InvDinamico.Domain.Entidades.Enums;

namespace InvDinamico.Domain.Messaging.Categoria
{
    public class AtualizarCategoriaRequest
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public SituacaoGenerica? Situacao { get; set; }
    }
}
