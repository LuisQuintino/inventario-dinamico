using InvDinamico.Domain.Entidades.Base;

namespace InvDinamico.Domain.Entidades
{
    public class Movimento : EntityBase
    {
        public override Guid? Codigo { get; set; }
        public Guid CodigoEstoque { get; set; }
        public int QtdEstoqueAntes { get; set; }
        public int QtdEstoqueDepois { get; set; }
        public int Diferenca { get; set; }
        public string Motivo { get; set; }
        public Guid CodigoOperador { get; set; }

        public override bool Auditavel { get; set; }
    }
}
