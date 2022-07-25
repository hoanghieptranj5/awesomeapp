using Repositories.Models.Electricity;

namespace AwesomeApp.Helper;

public interface IDataHelper
{
    IEnumerable<PriceModel> GetPriceModels();
}