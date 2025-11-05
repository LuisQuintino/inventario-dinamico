using InvDinamico.Domain.Entidades.Base;
using InvDinamico.Domain.Messaging.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvDinamico.Domain.Entidades
{
    [Table("Movimento")]
    public class Movimento : EntityBase
    {
        [Key]
        public override Guid? Codigo { get; set; }
        public Guid CodigoEstoque { get; set; }
        public int QtdEstoqueAntes { get; set; }
        public int QtdEstoqueDepois { get; set; }
        public int Diferenca { get; set; }
        public string Motivo { get; set; }
        public Guid CodigoOperador { get; set; }

        public override bool Auditavel { get; set; }

        public Movimento() {}

        public Movimento(Estoque estoque, Guid codigoOperador, int qtdMovimentada, string motivoMovimento, bool novoEstoque = false, int? diferencaEstoque = null)
        {
            CodigoEstoque = estoque.Codigo ?? throw new InvDinamicoException("Necessário informar estoque");
            CodigoOperador = codigoOperador;
            Motivo = motivoMovimento;
            Diferenca = qtdMovimentada;
            QtdEstoqueAntes = novoEstoque ? 0 : estoque.QtdEmEstoque;
            QtdEstoqueDepois = novoEstoque ? estoque.QtdEmEstoque : estoque.QtdEmEstoque + (int)diferencaEstoque;
        }
    }
}
