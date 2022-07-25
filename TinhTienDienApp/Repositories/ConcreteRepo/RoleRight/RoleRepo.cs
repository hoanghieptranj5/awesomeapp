using Amazon.DynamoDBv2.DataModel;
using TinhTienDienApp.Repositories.Base;
using TinhTienDienApp.Repositories.Models.RoleRight;

namespace TinhTienDienApp.Repositories.ConcreteRepo.RoleRight;

public class RoleRepo : BaseRepo<Role, string>
{
    public RoleRepo(IDynamoDBContext context) : base(context)
    {
    }
}