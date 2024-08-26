using AutoMapper;
using Banco.Application.DTOs;
using Banco.Domain.Entities;

namespace Banco.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTOPost>().ReverseMap();
            CreateMap<Conta, ContaDTO>().ReverseMap();
            CreateMap<Conta, ContaDTOPost>().ReverseMap();
        }
    }

}
