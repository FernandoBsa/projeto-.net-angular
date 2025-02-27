using AutoMapper;
using WebApi.Models.DTO;
using WebApi.Models.Entity;

namespace WebApi.Services.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Usuario, UsuarioListarDTO>();
    }
}