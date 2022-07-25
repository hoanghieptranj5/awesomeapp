using Amazon.DynamoDBv2.DataModel;
using Repositories.Abstract;
using Repositories.Models.RoleRight;

namespace Repositories.Concrete.RoleRight;

public class RoleRepo : HashKeyOnlyRepo<Role, string>
{
    public RoleRepo(IDynamoDBContext context) : base(context)
    {
    }
}