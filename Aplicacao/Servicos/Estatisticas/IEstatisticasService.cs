using desafio_itau.Domain._Models;
namespace desafio_itau.Aplicacao.Servicos.Estatisticas;

public interface IEstatisticasService
{
    public Estatistica EstatisticasEmUmMinuto();
}