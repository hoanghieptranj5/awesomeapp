using TinhTienDienApp.Models;

namespace TinhTienDienApp.Handlers;

public interface ICalculatorHandler
{
    public Task<CalculatedModel> Calculate(int usage);
}