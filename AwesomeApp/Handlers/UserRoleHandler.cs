using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using AwesomeApp.Controllers.Models;
using AwesomeApp.Handlers.Base;
using Repositories.Concrete.RoleRight;
using Repositories.Models.RoleRight;

namespace AwesomeApp.Handlers;

public class UserRoleHandler : IUserRoleHandler
{
    private readonly RightRepo _rightRepo;
    private readonly RoleRepo _roleRepo;
    private readonly UserRepo _userRepo;
    private readonly IMapper _mapper;

    public UserRoleHandler(UserRepo userRepo, RoleRepo roleRepo, RightRepo rightRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _roleRepo = roleRepo;
        _rightRepo = rightRepo;
        _mapper = mapper;
    }

    public async IAsyncEnumerable<RoleOutputModel> GetUserRoles(string userId)
    {
        var users = await _userRepo.GetList(new List<ScanCondition>());
        var user = users.Find(u => u.UserId == userId);
        if (user == null) yield break;
        foreach (var userRole in user.Roles)
        {
            var role = await _roleRepo.GetById(userRole.Role);
            if (role == null) continue;
            yield return new RoleOutputModel
            {
                RoleId = role.RoleId,
                Country = userRole.Country,
                Description = role.Description,
                Hierachy = role.Hierachy,
                TranslationKey = role.TranslationKey,
                Rights = role.Rights
            };
        }
    }

    public async IAsyncEnumerable<Right> GetUserRights(string userId)
    {
        var userRoles = GetUserRoles(userId);
        await foreach (var userRole in userRoles)
        {
            if (userRole == null) continue;

            var rightIds = userRole.Rights;
            foreach (var rightId in rightIds) yield return await _rightRepo.GetById(rightId);
        }
    }

    public async Task<string> CreateRight(CreateRightModel model)
    {
        var rightId = Guid.NewGuid().ToString();
        await _rightRepo.CreateOrUpdate(new Right
        {
            RightId = model.RightId,
            Description = model.Description,
            CreatedAt = DateTime.Now,
            CreatedBy = model.CreatedBy
        });

        return rightId;
    }

    public async Task<string> CreateRole(CreateRoleModel model)
    {
        var roleId = Guid.NewGuid().ToString();
        await _roleRepo.CreateOrUpdate(new Role
        {
            RoleId = roleId,
            Hierachy = model.Hierarchy,
            TranslationKey = model.TranslationKey,
            Description = model.Description,
            Rights = model.Rights
        });

        return roleId;
    }

    public async Task<string> CreateUser(CreateUserModel model)
    {
        var userId = Guid.NewGuid().ToString();

        var countryRoles = new List<CountryRole>();
        for (var i = 0; i < model.Countries.Count; i++)
            countryRoles.Add(new CountryRole
            {
                Country = model.Countries[i],
                Role = model.Roles[i]
            });

        await _userRepo.CreateOrUpdate(new User
        {
            UserId = userId,
            ForcePasswordChange = false,
            Roles = countryRoles,
            UserType = model.UserType,
            Status = model.Status
        });

        return userId;
    }

    public async IAsyncEnumerable<UserOutputModel> GetUsersWithRoleName()
    {
        var users = await _userRepo.GetList(new List<ScanCondition>());
        var roles = await _roleRepo.GetList(new List<ScanCondition>());
        
        foreach (var user in users)
        {
            foreach (var countryRole in user.Roles)
            {
                var roleName = roles.FirstOrDefault(x => x.RoleId == countryRole.Role)?.Description;
                countryRole.Role = roleName;
            }
            
            yield return _mapper.Map<User, UserOutputModel>(user);
        }
    }
    
    public async IAsyncEnumerable<UserOutputModel> GetUsersWithRoleId()
    {
        var users = await _userRepo.GetList(new List<ScanCondition>());
        var roles = await _roleRepo.GetList(new List<ScanCondition>());
        
        foreach (var user in users)
        {
            yield return _mapper.Map<User, UserOutputModel>(user);
        }
    }
}