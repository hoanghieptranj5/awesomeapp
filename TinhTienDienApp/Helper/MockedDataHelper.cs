using RepoBase.Models.Electricity;

namespace TinhTienDienApp.Helper;

public class MockedDataHelper : IDataHelper
{
    public IEnumerable<PriceModel> GetPriceModels()
    {
        return new List<PriceModel>
        {
            new()
            {
                From = 0,
                To = 25,
                Price = 1678
            },
            new()
            {
                From = 51,
                To = 76,
                Price = 1734
            },
            new()
            {
                From = 102,
                To = 152,
                Price = 2014
            },
            new()
            {
                From = 203,
                To = 253,
                Price = 2536
            },
            new()
            {
                From = 304,
                To = 354,
                Price = 2834
            },
            new()
            {
                From = 405,
                To = 10000,
                Price = 2927
            }
        };
    }
}