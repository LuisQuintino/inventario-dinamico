using Microsoft.AspNetCore.Mvc;

namespace InvDinamico.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected int ObterCodigoOperador()
        {
            var codigoUsuario = HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "CodigoOperador")?.Value;

            if (string.IsNullOrEmpty(codigoUsuario))
                throw new Exception("Código do Operador não encontrado.");

            return int.Parse(codigoUsuario);
        }
    }
}
