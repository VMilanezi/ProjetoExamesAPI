namespace Exames.API.Dtos;

public record UpdateExameDto
(
    string? NomePaciente,
    string? NomeExame,
    string? Descricao,
    DateTime? DataEncaminhamento,
    DateTime? DataExecucaoExame,
    int? Situacao,
    string? Observacao,
    string? ResultadoExame,
    DateTime? DataAtualizacao
);
