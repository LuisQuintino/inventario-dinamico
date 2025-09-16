using InvDinamico.Domain.Entidades.Base;
using InvDinamico.Domain.Messaging.Base;

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

        public Movimento() {}

        public Movimento(Estoque estoque, Guid codigoOperador, int qtdMovimentada, string motivoMovimento)
        {
            CodigoEstoque = estoque.Codigo ?? throw new InvDinamicoException("Necessário informar estoque");
            CodigoOperador = codigoOperador;
            Motivo = motivoMovimento;
            Diferenca = qtdMovimentada;
            QtdEstoqueAntes = estoque.QtdEmEstoque;
            QtdEstoqueDepois = estoque.QtdEmEstoque + (qtdMovimentada);
        }
    }
}
