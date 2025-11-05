using InvDinamico.Domain.Entidades.Base;
using InvDinamico.Domain.Messaging.Estoque;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvDinamico.Domain.Entidades
{
    [Table("Estoque")]
    public class Estoque : EntityBase
    {
        [Key]
        public override Guid? Codigo { get; set; }
        public string Nome { get; set; }
        public Guid CodigoCategoria { get; set; }
        public int QtdEmEstoque { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtUltimaAtualizacao { get; set; }
        public bool Perecivel { get; set; }
        public DateTime DtValidadeMedia { get; set; }
        public override bool Auditavel { get; set; } = true;

        public Estoque()
        {
        }

        public void AtualizarEstoque(AtualizarEstoqueRequest request)
        {
            Nome = request.Nome ?? Nome;
            CodigoCategoria = request.CodigoCategoria != CodigoCategoria ? request.CodigoCategoria : CodigoCategoria;
            QtdEmEstoque = request.NovaQtdEmEstoque;
            Perecivel = request.Perecivel ?? Perecivel;
            DtValidadeMedia = request.DtValidadeMedia ?? DtValidadeMedia;
        }
    }
}
