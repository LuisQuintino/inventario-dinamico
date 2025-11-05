using InvDinamico.Domain.Entidades.Base;
using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvDinamico.Domain.Entidades
{
    [Table("AuditTrail")]
    public class AuditTrail : EntityBase
    {
        [Key]
        public override Guid? Codigo { get; set; }
        public string JsonAntigo { get; set; }
        public string JsonNovo { get; set; }
        public string NomeEntidade { get; set; }
        public string Acao { get; set; }
        public DateTime DtAlteracao { get; set; }
        public string EmailOperador { get; set; }
        public Guid CodigoOperador { get; set; } 
        public override bool Auditavel { get; set; } = false;

        public AuditTrail()
        {
        }

        public AuditTrail(string jsonAntigo, string jsonNovo, string nomeEntidade, Entidades.Operador operadorAcao, string acao)
        {
            JsonAntigo = jsonAntigo;
            JsonNovo = jsonNovo;
            NomeEntidade = nomeEntidade;
            DtAlteracao = DateTime.Now;
            EmailOperador = operadorAcao.Email ?? string.Empty;
            CodigoOperador = operadorAcao.Codigo ?? Guid.Empty;
            Acao = acao;
        }
    }
}
