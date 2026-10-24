using DesafioItau.Aplicacao.Servicos.Transacoes;
using DesafioItau.Domain.Models;

namespace DesafioItau.Aplicacao.Servicos.Estatisticas;

public class EstatisticasService : IEstatisticasService
{
    private readonly ITransacaoService _transacaoService;

    public EstatisticasService(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    public Estatistica ObterEstatisticasDoUltimoMinuto()
    {
        var transacoesDoUltimoMinuto = _transacaoService.ObterTransacoesDoUltimoMinuto();
        if (transacoesDoUltimoMinuto.Count == 0)
        {
            return new Estatistica();
        }

        return new Estatistica
        {
            Count = transacoesDoUltimoMinuto.Count,
            Sum = transacoesDoUltimoMinuto.Sum(transacao => transacao.Valor!.Value),
            Max = transacoesDoUltimoMinuto.Max(transacao => transacao.Valor!.Value),
            Avg = transacoesDoUltimoMinuto.Average(transacao => transacao.Valor!.Value),
            Min = transacoesDoUltimoMinuto.Min(transacao => transacao.Valor!.Value),
        };
    }
}