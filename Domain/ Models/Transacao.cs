using System.ComponentModel.DataAnnotations;
namespace desafio_itau.Domain._Models;

public class Transacao
{
    [Required(ErrorMessage = "O campo 'Valor' é obrigatório.")]
    public Double Valor { get; set; }
    [Required(ErrorMessage = "O campo 'Data & Hora' é obrigatório.")]
    public DateTime DataHora { get; set; } = DateTime.Now;
}