using System.ComponentModel.DataAnnotations;

namespace Exames.API.Dtos;

public class CreateExameDto
{
    [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome do paciente deve ter no mínimo 3 caracteres.")]
    [MaxLength(255, ErrorMessage = "O nome do paciente deve ter no máximo 255 caracteres.")]
    public string? NomePaciente { get; set; }

    [Required(ErrorMessage = "O nome do exame é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome do exame deve ter no mínimo 3 caracteres.")]
    [MaxLength(255, ErrorMessage = "O nome do exame deve ter no máximo 255 caracteres.")]
    public string? NomeExame { get; set; }

    [MaxLength(255, ErrorMessage = "A descrição deve ter no máximo 255 caracteres.")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "A situação do exame é obrigatório.")]
    public int Situacao { get; set; }

    [MaxLength(1000, ErrorMessage = "A observação deve ter no máximo 1000 caracteres.")]
    public string? Observacao { get; set; }
}
