using InvDinamico.Domain.Entidades.Base;
using InvDinamico.Domain.Entidades.Enums;

namespace InvDinamico.Domain.Entidades
{
    public class Categoria : EntityBase
    {
        public override Guid? Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtUltimaAtualizacao { get; set; }
        public SituacaoGenerica Situacao { get; set; }
        public override bool Auditavel { get; set; } = true;
    }
}
