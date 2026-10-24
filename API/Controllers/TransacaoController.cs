using Microsoft.AspNetCore.Mvc;
using DesafioItau.Aplicacao.Servicos.Transacoes;
using DesafioItau.Domain.Models;

namespace DesafioItau.API.Controllers;

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
        
        var transacaoValida = _transacaoService.Transferir(transacao);
        if (!transacaoValida) return UnprocessableEntity("Por favor, insira um objeto válido."); // Erro 422.
        if (transacao is null) return BadRequest("O valor está nulo. Por favor, informar valores necessários."); // Erro 400
        return CreatedAtAction(nameof(RealizarTransacao), transacao); // Status 201 Created
    }


    [HttpDelete("transacao")]
    public IActionResult DeletarTransacao([FromBody] Transacao transacao)
    {
        if (transacao is null) return BadRequest("O valor está nulo. Por favor, informar valores necessários.");
        _transacaoService.DeletarTransacao(transacao);
        return Ok();
    }

}