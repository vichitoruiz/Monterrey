using AutoMapper;
using SSEL.MONTERREY.Application.DTOs;
using SSEL.MONTERREY.Domain.Entities;

namespace SSEL.MONTERREY.Application.Mappers
{
    /// <summary>
    /// Configuración central de AutoMapper.
    /// Define los mapeos entre entidades de dominio y DTOs.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeo bidireccional entre Usuario y UsuarioDTO
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
