using Microsoft.AspNetCore.Mvc;
using DesafioItau.Aplicacao.Servicos.Transacoes;
using DesafioItau.Domain.Models;

namespace DesafioItau.API.Controllers;

[ApiController]
[Route("transacao")]
public class TransacaoController : ControllerBase
{
    private readonly ITransacaoService _transacaoService;

    public TransacaoController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }


    [HttpPost]
    [Consumes("application/json")]
    public IActionResult RealizarTransacao([FromBody] Transacao transacao)
    {
        if (!ModelState.IsValid)
        {
            var jsonInvalido = ModelState.Any(entrada =>
                entrada.Value?.Errors.Count > 0 &&
                (entrada.Key == "$" || entrada.Key.StartsWith("$.", StringComparison.Ordinal) ||
                 entrada.Key.StartsWith("$[", StringComparison.Ordinal)));

            return SemCorpo(jsonInvalido ? StatusCodes.Status400BadRequest : StatusCodes.Status422UnprocessableEntity);
        }

        var transacaoValida = _transacaoService.Transferir(transacao);
        if (!transacaoValida) return SemCorpo(StatusCodes.Status422UnprocessableEntity);

        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpDelete]
    public IActionResult DeletarTransacao()
    {
        _transacaoService.LimparTransacoes();
        return Ok();
    }

    private EmptyResult SemCorpo(int statusCode)
    {
        Response.StatusCode = statusCode;
        Response.ContentLength = 0;
        return new EmptyResult();
    }
}