using InvDinamico.Domain.Services.Estoque;
using Microsoft.AspNetCore.Mvc;

namespace InvDinamico.API.Controllers
{
    public class EstoqueController : ControllerBase
    {
        public readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }
    }
}
