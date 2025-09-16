using InvDinamico.API.Controllers.Base;
using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Messaging.Categoria;
using InvDinamico.Domain.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvDinamico.API.Controllers
{
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public ActionResult Inserir(InserirCategoriaRequest inserirCategoria)
        {
            try
            {
                _categoriaService.Inserir(inserirCategoria);

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

        [HttpPut]
        public ActionResult Atualizar(AtualizarCategoriaRequest atualizarCategoria)
        {
            try
            {
                _categoriaService.Atualizar(atualizarCategoria);

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
        public ActionResult ListarCategorias(AtualizarCategoriaRequest atualizarCategoria)
        {
            try
            {
                return Ok(_categoriaService.ListarCategorias());
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
