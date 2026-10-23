using Microsoft.AspNetCore.Mvc;
using desafio_itau.Aplicacao.Servicos.Transacoes;
using desafio_itau.Domain._Models;
namespace desafio_itau.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransacaoController : ControllerBase
{
    private readonly ITransacaoService _transacaoService;
    public TransacaoController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }


    [HttpPost("transacao")]
    public IActionResult RealizarTransacao([FromBody] Transacao transacao)
    {
        
        _transacaoService.Transferir(transacao);
        return CreatedAtAction(nameof(RealizarTransacao), transacao);
    }


    [HttpDelete("transacao")]
    public IActionResult DeletarTransacao([FromBody] Transacao transacao)
    {
        _transacaoService.DeletarTransacao(transacao);
        return Ok();
    }

}