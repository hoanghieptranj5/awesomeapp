using AutoMapper;
using TinhTienDienApp.Controllers.Models;
using TinhTienDienApp.Repositories.Models.Hanzi;

namespace TinhTienDienApp.Mappers;

public class HanziProfile : Profile
{
    public HanziProfile()
    {
        CreateMap<HanziCreateModel, Hanzi>();
    }
}