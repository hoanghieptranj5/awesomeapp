using Amazon.DynamoDBv2.DataModel;
using RepoBase.Abstract;
using RepoBase.Models.Electricity;

namespace RepoBase.Concrete.Electricity;

public class ElectricityPriceRepo : HashKeyOnlyRepo<PriceModel, string>
{
    public ElectricityPriceRepo(IDynamoDBContext context) : base(context)
    {
    }
}