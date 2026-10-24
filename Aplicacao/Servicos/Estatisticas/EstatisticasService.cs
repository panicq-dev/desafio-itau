using desafio_itau.Aplicacao.Servicos.Transacoes;
using desafio_itau.Domain._Models;

namespace desafio_itau.Aplicacao.Servicos.Estatisticas;

public class EstatisticasService : IEstatisticasService
{
    private readonly ITransacaoService _transacaoService;

    public EstatisticasService(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    public Estatistica EstatisticasEmUmMinuto()
    {
        var transacoes = _transacaoService.ObterTransacoes();
        var estatisticas = new Estatistica()
        {
            Count = transacoes.Count,
            Sum = transacoes.Sum(t => t.Valor),
            Max = transacoes.Max(t => t.Valor),
            Avg = transacoes.Average(t => t.Valor),
            Min = transacoes.Min(t => t.Valor),
        };

        return estatisticas;
    }
}