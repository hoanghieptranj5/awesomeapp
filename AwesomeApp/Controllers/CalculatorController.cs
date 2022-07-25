using AwesomeApp.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeApp.Controllers;

/// <summary>
/// </summary>
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorHandler _calculatorHandler;

    /// <summary>
    /// </summary>
    /// <param name="calculatorHandler"></param>
    public CalculatorController(ICalculatorHandler calculatorHandler)
    {
        _calculatorHandler = calculatorHandler;
    }

    /// <summary>
    ///     The money you have to pay for your electricity usage
    /// </summary>
    /// <param name="usage">Must between 0 and 10.000</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(int usage)
    {
        var result = await _calculatorHandler.Calculate(usage);
        return Ok(result);
    }
}