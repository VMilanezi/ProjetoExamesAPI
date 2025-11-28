using Exames.API.Dtos;
using Exames.API.Models;

namespace Exames.API.Services.Interfaces;

public interface IExameService
{
    public Task<ResponseModel<List<ExameDto>?>> GetAllExamesAsync();
    public Task<ResponseModel<ExameDto?>> GetExameByIdAsync(int id);
    public Task<ResponseModel<ExameDto?>> CreateExameAsync(CreateExameDto dto);
    public Task<ResponseModel<ExameDto?>> UpdateExameAsync(int id, UpdateExameDto dto);
    public Task<ResponseModel<ExameDto?>> DeleteExameAsync(int id);
}
