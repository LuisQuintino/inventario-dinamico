using api_domain.Messaging.Authentication;
using InvDinamico.API.Controllers.Base;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Services.Autenticacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvDinamico.API.Controllers
{
    public class AutenticacaoController(IAutenticacaoService autenticacaoService) : BaseController
    {
        private readonly IAutenticacaoService _autenticacaoService = autenticacaoService;

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ResponseBase> Autenticar(AuthenticationDTO authRequest)
        {
            try
            {
                return Ok(_autenticacaoService.Autenticar(authRequest));
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
