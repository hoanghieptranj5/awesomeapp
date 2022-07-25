using Amazon.DynamoDBv2.DataModel;
using RepoBase.Abstract;
using RepoBase.Models.RoleRight;

namespace RepoBase.Concrete.RoleRight;

public class RightRepo : HashKeyOnlyRepo<Right, string>
{
    public RightRepo(IDynamoDBContext context) : base(context)
    {
    }
}