using AutoMapper;
using Exames.API.Dtos;
using Exames.API.Models;
using Exames.API.Repositories.Interfaces;
using Exames.API.Services.Interfaces;

namespace Exames.API.Services;

public class ExameService : IExameService
{
    private readonly IMapper _mapper;
    private IExameRepository _exameRepository;

    public ExameService(IMapper mapper, IExameRepository exameRepository)
    {
        _mapper = mapper;
        _exameRepository = exameRepository;
    }

    public async Task<ResponseModel<List<ExameDto>?>> GetAllExamesAsync()
    {
        try
        {
            var exameEntity = await _exameRepository.GetAllExamesAsync();
            var exameDto = _mapper.Map<List<ExameDto>>(exameEntity);
            return ResponseModel<List<ExameDto>>.Ok(exameDto, exameEntity.Count == 0 ? "Nenhum exame encontrado." : "Exames encontrados com sucesso!");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            return ResponseModel<List<ExameDto>>.Fail($"Erro interno: {ex.Message}.");
        }
    }

    public async Task<ResponseModel<ExameDto?>> GetExameByIdAsync(int id)
    {
        try
        {
            var exameEntity = await _exameRepository.GetExameByIdAsync(id);
            if (exameEntity is null) return ResponseModel<ExameDto>.Fail($"Nenhum exame encontrado com o ID informado. ID: {id}.");
            var exameDto = _mapper.Map<ExameDto>(exameEntity);
            return ResponseModel<ExameDto>.Ok(exameDto, "Exame encontrado com sucesso.");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ResponseModel<ExameDto>.Fail($"Erro interno: {ex.Message}.");
        }
    }

    public async Task<ResponseModel<ExameDto?>> CreateExameAsync(CreateExameDto dto)
    {
        try
        {
            var exameEntity = _mapper.Map<ExameModel>(dto);
            exameEntity.DataCriacao = DateTime.UtcNow;
            var createdExame = await _exameRepository.CreateExameAsync(exameEntity);
            var exameDto = _mapper.Map<ExameDto>(createdExame);
            return ResponseModel<ExameDto>.Ok(exameDto, "Exame cadastrado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ResponseModel<ExameDto>.Fail($"Erro interno: {ex.Message}.");
        }
    }

    public async Task<ResponseModel<ExameDto?>> UpdateExameAsync(int id, UpdateExameDto dto)
    {
        try
        {
            var exameEntity = await _exameRepository.GetExameByIdAsync(id);
            if (exameEntity is null) return ResponseModel<ExameDto>.Fail("Nenhum exame encontrado.");

            _mapper.Map(dto, exameEntity);
            exameEntity.DataAtualizacao = DateTime.UtcNow;

            await _exameRepository.UpdateExameAsync(exameEntity);
            var exameDto = _mapper.Map<ExameDto>(exameEntity);
            return ResponseModel<ExameDto>.Ok(exameDto, "Exame atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ResponseModel<ExameDto>.Fail($"Erro interno: {ex.Message}.");
        }
    }

    public async Task<ResponseModel<ExameDto?>> DeleteExameAsync(int id)
    {
        try
        {
            var exameEntity = await _exameRepository.GetExameByIdAsync(id);
            if (exameEntity is null) return ResponseModel<ExameDto>.Fail("Nenhum exame encontrado.");
            await _exameRepository.DeleteExameAsync(exameEntity.ExameId);
            return ResponseModel<ExameDto>.Ok(null, $"Exame deletado com sucesso. ID: {id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ResponseModel<ExameDto>.Fail($"Erro interno: {ex.Message}.");
        }
    }
}
