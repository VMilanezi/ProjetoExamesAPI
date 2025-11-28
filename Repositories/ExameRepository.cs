using Exames.API.Context;
using Exames.API.Models;
using Exames.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exames.API.Repositories;

public class ExameRepository: IExameRepository
{
    private readonly ExameDbContext _context;

    public ExameRepository(ExameDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExameModel>> GetAllExamesAsync()
    {
        return await _context.Exames.ToListAsync();
    }

    public async Task<ExameModel?> GetExameByIdAsync(int id)
    {
        return await _context.Exames.FirstOrDefaultAsync(u => u.ExameId == id);
    }

    public async Task<ExameModel> CreateExameAsync(ExameModel exame)
    {
        _context.Exames.Add(exame);
        await _context.SaveChangesAsync();
        return exame;
    }

    public async Task<ExameModel> UpdateExameAsync(ExameModel exame)
    {
        _context.Exames.Update(exame);
        await _context.SaveChangesAsync();
        return exame;
    }

    public async Task<ExameModel> DeleteExameAsync(int id)
    {
        var exame = await GetExameByIdAsync(id);
        _context.Exames.Remove(exame);
        await _context.SaveChangesAsync();
        return exame;
    }
}
