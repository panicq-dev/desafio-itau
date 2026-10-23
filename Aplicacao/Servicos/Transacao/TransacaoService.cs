using desafio_itau.Domain._Models;
namespace desafio_itau.Aplicacao.Servicos
{
    public class TransacaoService : ITransacaoService
    {
        private List<Transacao> transacoes = new List<Transacao>();
        
        public Estatistica Transferir(Transacao transacao)
        {
            if (transacao.DataHora > DateTime.Now)
            {
                throw new ArgumentException("Data e hora não devem ser futuras.");        
            }
            transacoes.Add(transacao);
            return new Estatistica();
        }

        public void DeletarTransacao(Transacao transacao)
        {
            if (!transacoes.Contains(transacao))
            {
                throw new ArgumentException("A transação não existe na lista.");
            }
            transacoes.Remove(transacao);
        }
    }
}