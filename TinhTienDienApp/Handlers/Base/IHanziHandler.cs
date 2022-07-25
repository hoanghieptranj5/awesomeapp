﻿using TinhTienDienApp.Controllers.Models;
using TinhTienDienApp.Repositories.Models.Hanzi;

namespace TinhTienDienApp.Handlers.Base;

public interface IHanziHandler
{
    Task<Hanzi> GetHanzi(string hashKey, int rangeKey);
    Task<List<Hanzi>> GetList();
    Task Create(HanziCreateModel hanzi);
    Task Update(HanziCreateModel hanzi);
    Task Delete(string id, int stroke);
    Task<List<Hanzi>> Find(string id);
}