using Exames.API.Models;

namespace Exames.API.Repositories.Interfaces;

public interface IExameRepository
{
    Task<List<ExameModel>> GetAllExamesAsync();
    Task<ExameModel?> GetExameByIdAsync(int id);
    Task<ExameModel> CreateExameAsync(ExameModel exame);
    Task<ExameModel> UpdateExameAsync(ExameModel exame);
    Task<ExameModel> DeleteExameAsync(int id);
}
