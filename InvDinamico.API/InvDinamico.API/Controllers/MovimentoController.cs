using InvDinamico.Domain.Services.Movimento;
using Microsoft.AspNetCore.Mvc;

namespace InvDinamico.API.Controllers
{
    public class MovimentoController(IMovimentoService movimentoService) : ControllerBase
    {
        public readonly IMovimentoService _movimentoService = movimentoService;
    }
}
