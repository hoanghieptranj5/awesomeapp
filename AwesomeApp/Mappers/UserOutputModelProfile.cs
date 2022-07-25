using AutoMapper;
using AwesomeApp.Controllers.Models;
using Repositories.Models.RoleRight;

namespace AwesomeApp.Mappers;

public class UserOutputModelProfile : Profile
{
    public UserOutputModelProfile()
    {
        CreateMap<User, UserOutputModel>();
    }
}