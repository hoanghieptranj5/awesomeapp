using AutoMapper;
using RepoBase.Models.Hanzi;
using TinhTienDienApp.Controllers.Models;

namespace TinhTienDienApp.Mappers;

public class HanziProfile : Profile
{
    public HanziProfile()
    {
        CreateMap<HanziCreateModel, Hanzi>();
    }
}