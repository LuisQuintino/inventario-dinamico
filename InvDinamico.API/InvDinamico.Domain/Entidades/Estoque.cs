using InvDinamico.Domain.Entidades.Base;

namespace InvDinamico.Domain.Entidades
{
    public class Estoque : EntityBase
    {
        public override Guid? Codigo { get; set; }
        public string Nome { get; set; }
        public Guid CodigoCategoria { get; set; }
        public int QtdEmEstoque { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtUltimaAtualizacao { get; set; }
        public bool Perecivel { get; set; }
        public DateTime DtValidadeMedia { get; set; }
        public override bool Auditavel { get; set; } = true;
    }
}
