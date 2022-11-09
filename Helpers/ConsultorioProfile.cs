using AutoMapper;
using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;

namespace Consultorio.Helpers
{
    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Paciente, PacienteDetalhesDto>();
               //.ForMember(dest => dest.Celular, src => src.Ignore());
            CreateMap<Consulta, ConsultaDTO>()
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));
            CreateMap<Paciente, PacienteAdicionarDTO>().ReverseMap();

            CreateMap<PacienteAtualizarDTO, Paciente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
