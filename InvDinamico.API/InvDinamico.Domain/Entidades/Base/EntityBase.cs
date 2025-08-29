using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvDinamico.Domain.Entidades.Base
{
    public abstract class EntityBase
    {
        public abstract Guid? Codigo { get; set; }

        [NotMapped]
        [JsonIgnore]
        public abstract bool Auditavel { get; set; }
    }
}
