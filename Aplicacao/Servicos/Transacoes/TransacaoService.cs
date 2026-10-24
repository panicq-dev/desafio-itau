using System.ComponentModel.DataAnnotations;
using DesafioItau.Domain.Models;

namespace DesafioItau.Aplicacao.Servicos.Transacoes;

public class TransacaoService : ITransacaoService
{
    private readonly List<Transacao> _transacoesRegistradas = [];
    private readonly Lock _lock = new();

    public bool Transferir(Transacao transacao)
    {
        try
        {
            Validator.ValidateObject(transacao, new ValidationContext(transacao), validateAllProperties: true);

            if (transacao.DataHora!.Value > DateTimeOffset.UtcNow)
            {
                return false;
            }

            lock (_lock)
            {
                _transacoesRegistradas.Add(transacao);
            }

            return true;
        }
        catch (ValidationException)
        {
            return false;
        }
    }

    public void LimparTransacoes()
    {
        lock (_lock)
        {
            _transacoesRegistradas.Clear();
        }
    }

    public List<Transacao> ObterTransacoesDoUltimoMinuto()
    {
        var limite = DateTimeOffset.UtcNow.AddSeconds(-60);

        lock (_lock)
        {
            return _transacoesRegistradas
                .Where(transacao => transacao.DataHora!.Value >= limite)
                .ToList();
        }
    }
}