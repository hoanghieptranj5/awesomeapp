using Amazon.DynamoDBv2.DataModel;
using TinhTienDienApp.Repositories.Base;

namespace TinhTienDienApp.Repositories.ConcreteRepo.Hanzi;

public class HanziRepo : HanziBaseRepo<Models.Hanzi.Hanzi, string, int>
{
    public HanziRepo(IDynamoDBContext context) : base(context)
    {
    }
}