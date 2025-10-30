using UstaPlatform.Domain.Entities;

namespace UstaPlatform.Domain.Collections;

public sealed class Schedule
{
    private readonly Dictionary<DateOnly, List<IsEmri>> _byDate = new();

    // Dizinleyici (Indexer): Schedule[gun] → o güne ait iş emirleri
    public List<IsEmri> this[DateOnly gun]
    {
        get
        {
            if (!_byDate.TryGetValue(gun, out var list))
            {
                list = new List<IsEmri>();
                _byDate[gun] = list;
            }
            return list;
        }
    }

    // Kolay erişim: tüm tarihler
    public IEnumerable<DateOnly> Gunler => _byDate.Keys;
}
