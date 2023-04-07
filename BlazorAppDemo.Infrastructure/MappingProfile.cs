using AutoMapper;
using BlazorAppDemo.Core.Entities;
using BlazorAppDemo.Shared.Print3dModels;
using static Azure.Core.HttpHeader;
using System.Reflection.PortableExecutable;
using System.Reflection;

namespace BlazorAppDemo.Server.BazorAppDemo.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<Email, EmailModel>().ReverseMap();
        CreateMap<Status, StatusModel>().ReverseMap();

    }

}
