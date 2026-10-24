using DesafioItau.Domain.Models;

namespace DesafioItau.Aplicacao.Servicos.Estatisticas;

public interface IEstatisticasService
{
    public Estatistica ObterEstatisticasDoUltimoMinuto();
}