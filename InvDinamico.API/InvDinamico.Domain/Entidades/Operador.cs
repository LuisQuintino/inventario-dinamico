using api_domain.Extensions;
using InvDinamico.Domain.Entidades.Base;
using InvDinamico.Domain.Entidades.Enums;
using InvDinamico.Domain.Messaging.Operador;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvDinamico.Domain.Entidades
{
    [Table("Operador")]
    public class Operador : EntityBase
    {
        [Key]
        public override Guid? Codigo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtSituacao { get; set; }
        public SituacaoOperador Situacao { get; set; }
        public TipoOperador TipoOperador { get; set; }  

        public Operador() { }

        public Operador(CadastrarOperadorRequest cadastrarOperadorRequest)
        {
            Email = cadastrarOperadorRequest.Email;
            Senha = StringCipher.GenerateHash(cadastrarOperadorRequest.Senha);
            DtInclusao = DateTime.Now;
            DtSituacao = DateTime.Now;
            Situacao = SituacaoOperador.Ativo;
            TipoOperador = cadastrarOperadorRequest.TipoOperador;
        }
    }
}
