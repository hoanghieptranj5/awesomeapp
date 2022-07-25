using Amazon.DynamoDBv2.DataModel;
using RepoBase.Concrete.Electricity;
using TinhTienDienApp.Helper;
using TinhTienDienApp.Models;

namespace TinhTienDienApp.Logics;

public class Calculator
{
    private readonly IDataHelper _helper;
    private readonly ElectricityPriceRepo _priceRepo;

    public Calculator(IDataHelper helper, ElectricityPriceRepo priceRepo)
    {
        _helper = helper;
        _priceRepo = priceRepo;
    }

    public async Task<CalculatedModel> Calculate(int usage)
    {
        var results = new CalculatedModel
        {
            Items = new List<CalculatedItem>()
        };

        // var models = _helper.GetPriceModels();
        var models = await _priceRepo.GetList(new List<ScanCondition>());
        models.Sort((x, y) => x.From - y.From);

        var remaining = usage;
        var total = 0.0f;

        foreach (var model in models)
            if (remaining >= model.To - model.From)
            {
                remaining -= model.To - model.From;
                total += model.Price * (model.To - model.From);

                results.Items.Add(new CalculatedItem
                {
                    From = model.From,
                    To = model.To,
                    StandardPrice = model.Price,
                    Price = model.Price * (model.To - model.From),
                    Usage = model.To - model.From
                });
                Console.WriteLine(
                    $"From {model.From} to {model.To}: {model.Price} * {model.To - model.From} = {model.Price * (model.To - model.From)}");
            }
            else
            {
                total += model.Price * remaining;

                results.Items.Add(new CalculatedItem
                {
                    From = model.From,
                    To = model.To,
                    StandardPrice = model.Price,
                    Price = model.Price * remaining,
                    Usage = remaining
                });

                Console.WriteLine(
                    $"From {model.From} to {model.To}: {model.Price} * {remaining} = {model.Price * remaining}");
                remaining = 0;
            }

        results.Usage = usage;
        results.Total = total;

        return results;
    }
}