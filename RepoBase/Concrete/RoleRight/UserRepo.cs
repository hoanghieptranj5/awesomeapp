using Amazon.DynamoDBv2.DataModel;
using RepoBase.Abstract;
using RepoBase.Models.RoleRight;

namespace RepoBase.Concrete.RoleRight;

public class UserRepo : HashKeyOnlyRepo<User, string>
{
    public UserRepo(IDynamoDBContext context) : base(context)
    {
    }
}