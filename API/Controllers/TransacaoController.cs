using Microsoft.AspNetCore.Mvc;
using desafio_itau.Domain._Models;
namespace desafio_itau.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransacaoController : ControllerBase
{
    [HttpPost("transacao")]
    public Estatistica RealizarTransacao([FromBody] Transacao transacao)
    {
        
        return new Estatistica();
    }


}