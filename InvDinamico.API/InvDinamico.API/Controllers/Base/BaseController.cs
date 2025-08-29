using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvDinamico.API.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected Guid ObterCodigoOperador()
        {
            var codigoUsuario = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "CodigoOperador")?.Value;

            if (string.IsNullOrWhiteSpace(codigoUsuario))
                throw new Exception("Código do Operador não encontrado.");

            return Guid.Parse(codigoUsuario);
        }
    }
}
