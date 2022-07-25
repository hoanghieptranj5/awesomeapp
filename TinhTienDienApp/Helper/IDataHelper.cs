using TinhTienDienApp.Repositories.Models.Electricity;

namespace TinhTienDienApp.Helper;

public interface IDataHelper
{
    IEnumerable<PriceModel> GetPriceModels();
}