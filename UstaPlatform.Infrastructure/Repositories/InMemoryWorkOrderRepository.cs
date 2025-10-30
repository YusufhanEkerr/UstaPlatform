using UstaPlatform.Domain.Entities;
using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.Infrastructure.Repositories;

public sealed class InMemoryWorkOrderRepository : IWorkOrderRepository
{
    private readonly List<IsEmri> _list = new();

    public void Add(IsEmri isEmri) => _list.Add(isEmri);

    public IEnumerable<IsEmri> GetAll() => _list;
}
