using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace TinhTienDienApp.Repositories.Base;

public class HanziBaseRepo<T, H, R>
{
    private readonly IDynamoDBContext _context;

    protected HanziBaseRepo(IDynamoDBContext context)
    {
        _context = context;
    }

    public virtual async Task<T> GetById(H hashKey, R rangeKey)
    {
        var result = await _context.LoadAsync<T>(hashKey, rangeKey);
        return result;
    }

    public virtual async Task<List<T>> GetList(IEnumerable<ScanCondition> conditions)
    {
        var result = await _context.ScanAsync<T>(conditions).GetRemainingAsync();
        return result;
    }

    public virtual async Task CreateOrUpdate(T value)
    {
        await _context.SaveAsync(value);
    }

    public virtual async Task Delete(T value)
    {
        await _context.DeleteAsync(value);
    }

    public virtual async Task<List<T>> Find<T>(string id)
    {
        var query = new QueryOperationConfig
        {
            IndexName = "simplified-index",
            Filter = new QueryFilter("simplified", QueryOperator.Equal, id)
        };

        return await _context
            .FromQueryAsync<T>(query)
            .GetRemainingAsync();
    }
}