using Amazon.DynamoDBv2.DataModel;
using Repositories.Abstract;
using Repositories.Models.RoleRight;

namespace Repositories.Concrete.RoleRight;

public class RightRepo : HashKeyOnlyRepo<Right, string>
{
    public RightRepo(IDynamoDBContext context) : base(context)
    {
    }
}