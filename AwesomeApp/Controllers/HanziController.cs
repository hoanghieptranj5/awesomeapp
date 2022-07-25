using AwesomeApp.Controllers.Models;
using AwesomeApp.Handlers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeApp.Controllers;

[Route("api/[controller]")]
public class HanziController : ControllerBase
{
    private readonly IHanziHandler _hanziHandler;

    public HanziController(IHanziHandler hanziHandler)
    {
        _hanziHandler = hanziHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(string id, int strokes)
    {
        var hanzi = await _hanziHandler.GetHanzi(id, strokes);
        if (hanzi == null)
            return NotFound();
        return Ok(hanzi);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetList()
    {
        var hanzis = await _hanziHandler.GetList();
        if (!hanzis.Any())
            return NotFound();
        return Ok(hanzis);
    }

    [HttpPost]
    public async Task CreateHanzi(HanziCreateModel hanzi)
    {
        await _hanziHandler.Create(hanzi);
    }

    [HttpPut]
    public async Task UpdateHanzi(HanziCreateModel hanzi)
    {
        await _hanziHandler.Update(hanzi);
    }

    [HttpDelete]
    public async Task DeleteHanzi(string id, int strokes)
    {
        await _hanziHandler.Delete(id, strokes);
    }

    [HttpGet("find")]
    public async Task<IActionResult> Find(string id)
    {
        var result = await _hanziHandler.Find(id);
        return Ok(result);
    }
}