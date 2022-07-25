using AutoMapper;
using RepoBase.Models.RoleRight;
using TinhTienDienApp.Controllers.Models;

namespace TinhTienDienApp.Mappers;

public class UserOutputModelProfile : Profile
{
    public UserOutputModelProfile()
    {
        CreateMap<User, UserOutputModel>();
    }
}