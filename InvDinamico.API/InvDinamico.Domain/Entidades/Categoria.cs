using InvDinamico.Domain.Entidades.Base;
using InvDinamico.Domain.Entidades.Enums;
using InvDinamico.Domain.Messaging.Categoria;

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

        public Categoria()
        {
        }

        public Categoria(string nome)
        {
            Nome = nome;
            DtInclusao = DateTime.Now;
            DtUltimaAtualizacao = DateTime.Now;
            Situacao = SituacaoGenerica.Habilitado;
        }
    }
}
