using DesafioItau.Aplicacao.Servicos.Estatisticas;
using Microsoft.AspNetCore.Mvc;
using DesafioItau.Domain.Models;

namespace DesafioItau.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstatisticaController : ControllerBase
    {
        private readonly IEstatisticasService _estatisticasService;

        public EstatisticaController(IEstatisticasService estatisticasService)
        {
            _estatisticasService = estatisticasService;
        }

        [HttpGet("estatistica")]
        public ActionResult<Estatistica> ObterEstatisticasDaUltimaHora()
        {
            var estatisticasDaUltimaHora = _estatisticasService.ObterEstatisticasDaUltimaHora();
            return Ok(estatisticasDaUltimaHora);
        }
    }
}