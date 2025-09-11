using InvDinamico.Domain.Services.Categoria;
using Microsoft.AspNetCore.Mvc;

namespace InvDinamico.API.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
    }
}
