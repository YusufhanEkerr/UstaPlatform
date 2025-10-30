using System.Collections;
using UstaPlatform.Domain.Entities;

namespace UstaPlatform.Domain.Collections;

public sealed class Route : IEnumerable<(int X, int Y)>
{
    private readonly List<(int X, int Y)> _points = new();

    // Koleksiyon başlatıcı desteği için Add metodu
    public void Add(int x, int y) => _points.Add((x, y));

    // IEnumerable<T> implementasyonu
    public IEnumerator<(int X, int Y)> GetEnumerator() => _points.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Opsiyonel: uzaklık hesaplaması için basit metot
    public int ToplamDurak => _points.Count;
}
