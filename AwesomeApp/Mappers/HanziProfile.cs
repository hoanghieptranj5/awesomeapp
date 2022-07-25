using AutoMapper;
using AwesomeApp.Controllers.Models;
using Repositories.Models.Hanzi;

namespace AwesomeApp.Mappers;

public class HanziProfile : Profile
{
    public HanziProfile()
    {
        CreateMap<HanziCreateModel, Hanzi>();
    }
}