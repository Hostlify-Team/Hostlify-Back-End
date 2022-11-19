using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Infraestructure;

namespace Hostlify.API.Mapper;

public class ResourceToModel : Profile
{
    public ResourceToModel()
    {
        CreateMap<HistoryResource, History>();
    }
}