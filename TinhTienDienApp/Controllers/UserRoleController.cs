using Microsoft.AspNetCore.Mvc;
using RepoBase.Models.RoleRight;
using TinhTienDienApp.Controllers.Models;
using TinhTienDienApp.Handlers.Base;

namespace TinhTienDienApp.Controllers;

[Route("[controller]")]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleHandler _userRoleHandler;

    public UserRoleController(IUserRoleHandler userRoleHandler)
    {
        _userRoleHandler = userRoleHandler;
    }
    
    [HttpGet("list-users")]
    public async Task<IActionResult> GetUsers()
    {
        var result = new List<UserOutputModel>();
        var usersAsync = _userRoleHandler.GetUsersWithRoleName();
        await foreach (var user in usersAsync) result.Add(user);

        return Ok(result);
    }
    
    [HttpGet("list-users-with-roleId")]
    public async Task<IActionResult> GetUsersWithRoleId()
    {
        var result = new List<UserOutputModel>();
        var usersAsync = _userRoleHandler.GetUsersWithRoleId();
        await foreach (var user in usersAsync) result.Add(user);

        return Ok(result);
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetUserRoles(string userId)
    {
        var result = new List<RoleOutputModel>();
        var roleAynsc = _userRoleHandler.GetUserRoles(userId);
        await foreach (var role in roleAynsc) result.Add(role);

        return Ok(result);
    }

    [HttpGet("rights")]
    public async Task<IActionResult> GetUserRights(string userId)
    {
        var result = new List<Right>();
        var rightAsync = _userRoleHandler.GetUserRights(userId);
        await foreach (var right in rightAsync)
        {
            if (right == null) continue;
            result.Add(right);
        }

        return Ok(result);
    }

    [HttpPost("create-right")]
    public async Task<IActionResult> CreateNewRight(CreateRightModel model)
    {
        var created = await _userRoleHandler.CreateRight(model);
        return Ok(created);
    }

    [HttpPost("create-role")]
    public async Task<IActionResult> CreateNewRole(CreateRoleModel model)
    {
        var created = await _userRoleHandler.CreateRole(model);
        return Ok(created);
    }

    [HttpPost("create-user")]
    public async Task<IActionResult> CreateNewUser(CreateUserModel model)
    {
        var created = await _userRoleHandler.CreateUser(model);
        return Ok(created);
    }
}