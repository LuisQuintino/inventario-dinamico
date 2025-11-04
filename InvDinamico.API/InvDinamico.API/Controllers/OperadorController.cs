using InvDinamico.API.Controllers.Base;
using InvDinamico.Domain.Entidades;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Messaging.Operador;
using InvDinamico.Domain.Services.Operador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvDinamico.API.Controllers
{
    public class OperadorController(IOperadorService operadorService) : BaseController
    {
        private readonly IOperadorService _operadorService = operadorService;

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CadastrarOperador(CadastrarOperadorRequest cadastrarOperadorRequest){
            try
            {
                _operadorService.CadastrarOperador(cadastrarOperadorRequest);
                return Ok();
            }
            catch (InvDinamicoException invEx)
            {
                return BadRequest(new ResponseBase
                {
                    Sucesso = false,
                    MsgErro = invEx.Message
                });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult AtualizarOperador(AtualizarOperadorRequest atualizarOperadorRequest)
        {
            try
            {
                _operadorService.AtualizarOperador(atualizarOperadorRequest, ObterCodigoOperador());
                return Ok();
            }
            catch (InvDinamicoException invEx)
            {
                return BadRequest(new ResponseBase
                {
                    Sucesso = false,
                    MsgErro = invEx.Message
                });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<Operador> ObterTodos()
        {
            try
            {
                return Ok(_operadorService.ObterTodos());
            }
            catch (InvDinamicoException invEx)
            {
                return BadRequest(new ResponseBase
                {
                    Sucesso = false,
                    MsgErro = invEx.Message
                });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
