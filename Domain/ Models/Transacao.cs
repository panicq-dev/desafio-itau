using System.ComponentModel.DataAnnotations;
namespace desafio_itau.Domain._Models;

public class Transacao
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "O valor mínimo deve ser 1.")]
    public Double Valor { get; set; }
    [Required(ErrorMessage = "O campo 'Data & Hora' é obrigatório.")]
    public DateTime DataHora { get; set; } = DateTime.Now;
}