using API_EF.Data.Dtos;
using API_EF.Models;
using AutoMapper;

namespace API_EF.Profiles;

public class ClientesProfile : Profile
{
    public ClientesProfile()
    {
        CreateMap<CreateClienteDto, Clientes>();
        CreateMap<Clientes, ReadClienteDto>();
        CreateMap<UpdateClienteDto, Clientes>();
        CreateMap<Clientes, UpdateClienteDto>();
    }
}
