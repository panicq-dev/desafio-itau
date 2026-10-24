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

    public Estatistica ObterEstatisticasDaUltimaHora()
    {
        var transacoesDaUltimaHora = _transacaoService.ObterTransacoesNaUltimaHora();
        var estatisticasDaUltimaHora = new Estatistica()
        {
            Count = transacoesDaUltimaHora.Count,
            Sum = transacoesDaUltimaHora.Sum(transacao => transacao.Valor),
            Max = transacoesDaUltimaHora.Max(transacao => transacao.Valor),
            Avg = transacoesDaUltimaHora.Average(transacao => transacao.Valor),
            Min = transacoesDaUltimaHora.Min(transacao => transacao.Valor),
        };
        return estatisticasDaUltimaHora;
    }
}