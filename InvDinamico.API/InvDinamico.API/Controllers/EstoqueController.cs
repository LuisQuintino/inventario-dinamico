using InvDinamico.API.Controllers.Base;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Messaging.Estoque;
using InvDinamico.Domain.Services.Estoque;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvDinamico.API.Controllers
{
    public class EstoqueController : BaseController
    {
        public readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService){
            _estoqueService = estoqueService;
        }

        [HttpPost]
        public ActionResult InserirNovoEstoque(InserirEstoqueRequest inserirEstoqueRequest)
        {
            try
            {
                _estoqueService.InserirNovoEstoque(inserirEstoqueRequest, ObterCodigoOperador());
                return Ok(new ResponseBase
                {
                    Sucesso = true
                });
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
        public ActionResult ListarEstoques()
        {
            try
            {
                var estoquesLista = _estoqueService.ListarEstoques();
                return Ok(estoquesLista);
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
