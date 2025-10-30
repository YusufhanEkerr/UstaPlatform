using UstaPlatform.Domain.Entities;
using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.Infrastructure.Repositories;

public sealed class InMemoryUstaRepository : IUstaRepository
{
    private readonly List<Usta> _ustalar;

    public InMemoryUstaRepository(IEnumerable<Usta> seed)
        => _ustalar = seed.ToList();

    public IEnumerable<Usta> GetByExpertise(string uzmanlik)
        => _ustalar.Where(u => u.Uzmanlik == uzmanlik);

    public void Update(Usta usta)
    {
        // Demo amaçlı: no-op veya istersen burada listede bulup güncelleyebilirsin
    }
}
