using desafio_itau.Domain._Models;
namespace desafio_itau.Aplicacao.Servicos;
public interface ITransacaoService
{
    public Estatistica Transferir(Transacao transacao);        
}
