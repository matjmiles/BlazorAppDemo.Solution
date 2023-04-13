using AutoMapper;
using BlazorAppDemo.Core.Entities;
using BlazorAppDemo.Shared.Print3dModels;

namespace BlazorAppDemo.Server.BazorAppDemo.Infrastructure;

public class MappingProfile : Profile{
    public MappingProfile()
    {
        CreateMap<Email, EmailModel>().ReverseMap();
        CreateMap<Status, StatusModel>().ReverseMap();

    }
}
