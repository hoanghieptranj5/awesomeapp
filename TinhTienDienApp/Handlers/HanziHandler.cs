using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using RepoBase.Concrete.Hanzi;
using RepoBase.Models.Hanzi;
using TinhTienDienApp.Controllers.Models;
using TinhTienDienApp.Handlers.Base;

namespace TinhTienDienApp.Handlers;

public class HanziHandler : IHanziHandler
{
    private readonly HanziRepo _hanziRepo;
    private readonly IMapper _mapper;

    public HanziHandler(IMapper mapper, HanziRepo hanziRepo)
    {
        _mapper = mapper;
        _hanziRepo = hanziRepo;
    }


    public async Task<Hanzi> GetHanzi(string hashKey, int rangeKey)
    {
        return await _hanziRepo.GetById(hashKey, rangeKey);
    }

    public async Task<List<Hanzi>> GetList()
    {
        return await _hanziRepo.GetList(Array.Empty<ScanCondition>());
    }

    public async Task Create(HanziCreateModel hanzi)
    {
        var uuid = Guid.NewGuid();
        var hanziModel = _mapper.Map<HanziCreateModel, Hanzi>(hanzi);
        hanziModel.HanziId = uuid.ToString();

        await _hanziRepo.CreateOrUpdate(hanziModel);
    }

    public Task Update(HanziCreateModel hanzi)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(string id, int stroke)
    {
        var hanzi = await GetHanzi(id, stroke);
        await _hanziRepo.Delete(hanzi);
    }

    public async Task<List<Hanzi>> Find(string id)
    {
        return await _hanziRepo.Find<Hanzi>(id);
    }

    public async Task Delete(Hanzi hanzi)
    {
        await _hanziRepo.Delete(hanzi);
    }
}