using desafio_itau.Domain._Models;
namespace desafio_itau.Aplicacao.Servicos.Transacoes;

public interface ITransacaoService
{
    public bool Transferir(Transacao transacao);
    public void DeletarTransacao(Transacao transacao);
    public List<Transacao> ObterTransacoes();
}
