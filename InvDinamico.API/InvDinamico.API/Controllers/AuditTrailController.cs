using InvDinamico.API.Controllers.Base;
using InvDinamico.Domain.Entidades;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Messaging.Operador;
using InvDinamico.Domain.Services.AuditTrail;
using InvDinamico.Domain.Services.Operador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvDinamico.API.Controllers
{
    public class AuditTrailController(IAuditTrailService auditTrailService) : BaseController
    {
        private readonly IAuditTrailService _auditTrailService = auditTrailService;


        [HttpGet("{filtro}")]
        public ActionResult ObterAuditorias(string filtro = null){
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
