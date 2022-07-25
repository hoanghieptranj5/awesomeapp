using Amazon.DynamoDBv2.DataModel;
using TinhTienDienApp.Repositories.Base;
using TinhTienDienApp.Repositories.Models.Electricity;

namespace TinhTienDienApp.Repositories.ConcreteRepo.Electricity;

public class ElectricityPriceRepo : BaseRepo<PriceModel, string>
{
    public ElectricityPriceRepo(IDynamoDBContext context) : base(context)
    {
    }
}