using DesafioItau.Aplicacao.Servicos.Estatisticas;
using Microsoft.AspNetCore.Mvc;
using DesafioItau.Domain.Models;

namespace DesafioItau.API.Controllers
{
    [ApiController]
    [Route("estatistica")]
    public class EstatisticaController : ControllerBase
    {
        private readonly IEstatisticasService _estatisticasService;

        public EstatisticaController(IEstatisticasService estatisticasService)
        {
            _estatisticasService = estatisticasService;
        }

        [HttpGet]
        public ActionResult<Estatistica> ObterEstatisticasDoUltimoMinuto()
        {
            var estatisticasDoUltimoMinuto = _estatisticasService.ObterEstatisticasDoUltimoMinuto();
            return Ok(estatisticasDoUltimoMinuto);
        }
    }
}