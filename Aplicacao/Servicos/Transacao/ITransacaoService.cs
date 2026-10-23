using desafio_itau.Domain._Models;
namespace desafio_itau.Aplicacao.Servicos;
public interface ITransacaoService
{
    public void Transferir(Transacao transacao);
    public void DeletarTransacao(Transacao transacao);        
}
