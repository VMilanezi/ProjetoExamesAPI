using Exames.API.Models;

namespace Exames.API.Dtos;

public class ExameDto
{
    public int ExameId { get; set; }
    public string? NomePaciente { get; set; }
    public string? NomeExame { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataEncaminhamento { get; set; } = DateTime.UtcNow;
    public DateTime? DataExecucaoExame { get; set; }
    public int Situacao { get; set; }
    public string? Observacao { get; set; }
    public string? ResultadoExame { get; set; }
}
