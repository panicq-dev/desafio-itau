using System.ComponentModel.DataAnnotations;

namespace DesafioItau.Domain.Models;

public class Transacao
{
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser igual ou maior que zero.")]
    public double? Valor { get; set; }

    [Required(ErrorMessage = "O campo 'dataHora' é obrigatório.")]
    public DateTimeOffset? DataHora { get; set; }
}