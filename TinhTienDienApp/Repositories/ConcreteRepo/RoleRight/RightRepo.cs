using Amazon.DynamoDBv2.DataModel;
using TinhTienDienApp.Repositories.Base;
using TinhTienDienApp.Repositories.Models.RoleRight;

namespace TinhTienDienApp.Repositories.ConcreteRepo.RoleRight;

public class RightRepo : BaseRepo<Right, string>
{
    public RightRepo(IDynamoDBContext context) : base(context)
    {
    }
}