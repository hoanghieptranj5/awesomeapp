using TinhTienDienApp.Controllers.Models;
using TinhTienDienApp.Repositories.Models.RoleRight;

namespace TinhTienDienApp.Handlers.Base;

public interface IUserRoleHandler
{
    IAsyncEnumerable<RoleOutputModel> GetUserRoles(string userId);
    IAsyncEnumerable<Right> GetUserRights(string userId);
    Task<string> CreateRight(CreateRightModel model);
    Task<string> CreateRole(CreateRoleModel model);
    Task<string> CreateUser(CreateUserModel model);
    IAsyncEnumerable<UserOutputModel> GetUsersWithRoleName();
    IAsyncEnumerable<UserOutputModel> GetUsersWithRoleId();
}