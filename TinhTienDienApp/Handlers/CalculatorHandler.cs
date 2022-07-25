using TinhTienDienApp.Logics;
using TinhTienDienApp.Models;

namespace TinhTienDienApp.Handlers;

public class CalculatorHandler : ICalculatorHandler
{
    private readonly Calculator _calculator;

    public CalculatorHandler(Calculator calculator)
    {
        _calculator = calculator;
    }

    public async Task<CalculatedModel> Calculate(int usage)
    {
        var result = await _calculator.Calculate(usage);
        return result;
    }
}