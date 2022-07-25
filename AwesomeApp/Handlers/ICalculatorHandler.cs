using AwesomeApp.Models;

namespace AwesomeApp.Handlers;

public interface ICalculatorHandler
{
    public Task<CalculatedModel> Calculate(int usage);
}