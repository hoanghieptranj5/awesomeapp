using Amazon.DynamoDBv2.DataModel;
using TinhTienDienApp.Repositories.Base;
using TinhTienDienApp.Repositories.Models.RoleRight;

namespace TinhTienDienApp.Repositories.ConcreteRepo.RoleRight;

public class UserRepo : BaseRepo<User, string>
{
    public UserRepo(IDynamoDBContext context) : base(context)
    {
    }
}