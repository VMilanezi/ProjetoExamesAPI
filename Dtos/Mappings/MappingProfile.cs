using AutoMapper;
using Exames.API.Models;

namespace Exames.API.Dtos.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ExameDto, ExameModel>()
            .ForAllMembers(opt
                => opt.Condition((_, _, srcMember)
                    => srcMember is not null));

        CreateMap<ExameModel, ExameDto>();

        CreateMap<CreateExameDto, ExameModel>()
            .ForMember(dest => dest.ExameId, opt => opt.Ignore())
            .ForMember(dest => dest.DataEncaminhamento, opt => opt.Ignore())
            .ForMember(dest => dest.DataExecucaoExame, opt => opt.Ignore())
            .ForMember(dest => dest.ResultadoExame, opt => opt.Ignore())
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore());

        CreateMap<UpdateExameDto, ExameModel>()
                .ForMember(dest => dest.ExameId, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataEncaminhamento, opt => opt.Ignore())
                .ForMember(dest => dest.NomePaciente, opt => opt.Condition(src => src.NomePaciente != null))
                .ForMember(dest => dest.NomeExame, opt => opt.Condition(src => src.NomeExame != null))
                .ForMember(dest => dest.Descricao, opt => opt.Condition(src => src.Descricao != null))
                .ForMember(dest => dest.DataExecucaoExame, opt => opt.Condition(src => src.DataExecucaoExame != null))
                .ForMember(dest => dest.Situacao, opt => opt.Condition(src => src.Situacao != null))
                .ForMember(dest => dest.Observacao, opt => opt.Condition(src => src.Observacao != null))
                .ForMember(dest => dest.ResultadoExame, opt => opt.Condition(src => src.ResultadoExame != null));
    }
}
