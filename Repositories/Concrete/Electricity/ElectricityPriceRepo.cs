using Amazon.DynamoDBv2.DataModel;
using Repositories.Abstract;
using Repositories.Models.Electricity;

namespace Repositories.Concrete.Electricity;

public class ElectricityPriceRepo : HashKeyOnlyRepo<PriceModel, string>
{
    public ElectricityPriceRepo(IDynamoDBContext context) : base(context)
    {
    }
}