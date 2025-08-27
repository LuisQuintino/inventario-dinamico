using InvDinamico.API.Controllers.Base;
using InvDinamico.Domain.Messaging.Operador;
using InvDinamico.Domain.Services.Operador;
using Microsoft.AspNetCore.Mvc;

namespace InvDinamico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperadorController(IOperadorService operadorService) : BaseController
    {
        private readonly IOperadorService _operadorService = operadorService;

        [HttpPost]
        public ActionResult CadastrarOperador(CadastrarOperadorRequest cadastrarOperadorRequest)
        {
            try
            {
                _operadorService.CadastrarOperador(cadastrarOperadorRequest);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
