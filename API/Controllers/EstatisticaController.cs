using Microsoft.AspNetCore.Mvc;
using desafio_itau.Domain._Models;
namespace desafio_itau.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstatisticaController : ControllerBase
    {
        [HttpGet("estatistica")]
        public ActionResult<Estatistica> ObterEstatistica(List<Transacao> transacoes)
        {
            
            return Ok(new Estatistica());
        }
    }
}