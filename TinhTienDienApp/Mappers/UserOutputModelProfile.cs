using AutoMapper;
using TinhTienDienApp.Controllers.Models;
using TinhTienDienApp.Repositories.Models.RoleRight;

namespace TinhTienDienApp.Mappers;

public class UserOutputModelProfile : Profile
{
    public UserOutputModelProfile()
    {
        CreateMap<User, UserOutputModel>();
    }
}