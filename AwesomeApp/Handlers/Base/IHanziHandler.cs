using AwesomeApp.Controllers.Models;
using Repositories.Models.Hanzi;

namespace AwesomeApp.Handlers.Base;

public interface IHanziHandler
{
    Task<Hanzi> GetHanzi(string hashKey, int rangeKey);
    Task<List<Hanzi>> GetList();
    Task Create(HanziCreateModel hanzi);
    Task Update(HanziCreateModel hanzi);
    Task Delete(string id, int stroke);
    Task<List<Hanzi>> Find(string id);
}