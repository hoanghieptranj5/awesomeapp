using Amazon.DynamoDBv2.DataModel;
using RepoBase.Abstract;
using RepoBase.Models.RoleRight;

namespace RepoBase.Concrete.RoleRight;

public class RoleRepo : HashKeyOnlyRepo<Role, string>
{
    public RoleRepo(IDynamoDBContext context) : base(context)
    {
    }
}