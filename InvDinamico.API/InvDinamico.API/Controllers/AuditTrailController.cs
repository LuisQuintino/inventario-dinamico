using InvDinamico.API.Controllers.Base;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Services.AuditTrail;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvDinamico.API.Controllers
{
    public class AuditTrailController(IAuditTrailService auditTrailService) : BaseController
    {
        private readonly IAuditTrailService _auditTrailService = auditTrailService;


        [HttpGet]
        public ActionResult ObterAuditorias([FromQuery] string filtro = null)
        {
            try
            {
                return Ok(_auditTrailService.ObterAuditorias(filtro));
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
