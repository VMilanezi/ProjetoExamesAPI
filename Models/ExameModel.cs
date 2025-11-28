using System.ComponentModel.DataAnnotations;

namespace Exames.API.Models;

public class ExameModel
{
    [Key]
    public int ExameId { get; set; }
    public required string NomePaciente { get; set; }
    public required string NomeExame { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataEncaminhamento { get; set; } = DateTime.UtcNow;
    public DateTime? DataExecucaoExame { get; set; }
    public required int Situacao { get; set; }
    public string? Observacao { get; set; }
    public string? ResultadoExame { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public DateTime? DataAtualizacao { get; set; }
}
