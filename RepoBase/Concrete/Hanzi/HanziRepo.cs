using Amazon.DynamoDBv2.DataModel;
using RepoBase.Abstract;

namespace RepoBase.Concrete.Hanzi;

public class HanziRepo : HashAndRangeKeyRepo<Models.Hanzi.Hanzi, string, int>
{
    public HanziRepo(IDynamoDBContext context) : base(context)
    {
    }
}