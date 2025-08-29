using InvDinamico.Domain.Entidades;
using System.Security.Claims;

namespace api_domain.Extensions
{
    public static class ClaimsExtensions
    {
        public static IEnumerable<Claim> ObterClaims(this Operador operador)
            => new List<Claim>
            {
                new(ClaimTypes.Email, operador.Email),
                new("CodigoOperador", operador.Codigo.ToString())
            };
    }
}
