using Amazon.DynamoDBv2.DataModel;

namespace TinhTienDienApp.Repositories.Base;

public class BaseRepo<T, H>
{
    private readonly IDynamoDBContext _context;

    protected BaseRepo(IDynamoDBContext context)
    {
        _context = context;
    }

    public virtual async Task<T> GetById(H hashKey)
    {
        var result = await _context.LoadAsync<T>(hashKey);
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
}