using Microsoft.AspNetCore.Mvc;

namespace TinhTienDienApp.Controllers;

/// <summary>
///     Controller uses for testing purpose only
/// </summary>
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    // GET api/values
    /// <summary>
    ///     Endpoint for testing purpose, return hardcoded strings
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] {"value1", "value2"};
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}