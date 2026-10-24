using DesafioItau.Domain.Models;

namespace DesafioItau.Aplicacao.Servicos.Transacoes;

public interface ITransacaoService
{
    public bool Transferir(Transacao transacao);
    public void DeletarTransacao(Transacao transacao);
    public List<Transacao> ObterTransacoesNaUltimaHora();
}
