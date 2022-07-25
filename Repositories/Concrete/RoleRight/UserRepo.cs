using Amazon.DynamoDBv2.DataModel;
using Repositories.Abstract;
using Repositories.Models.RoleRight;

namespace Repositories.Concrete.RoleRight;

public class UserRepo : HashKeyOnlyRepo<User, string>
{
    public UserRepo(IDynamoDBContext context) : base(context)
    {
    }
}