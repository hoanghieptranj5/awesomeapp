using Amazon.DynamoDBv2.DataModel;
using Repositories.Abstract;

namespace Repositories.Concrete.Hanzi;

public class HanziRepo : HashAndRangeKeyRepo<Models.Hanzi.Hanzi, string, int>
{
    public HanziRepo(IDynamoDBContext context) : base(context)
    {
    }
}