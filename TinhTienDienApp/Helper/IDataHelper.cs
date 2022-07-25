using RepoBase.Models.Electricity;

namespace TinhTienDienApp.Helper;

public interface IDataHelper
{
    IEnumerable<PriceModel> GetPriceModels();
}