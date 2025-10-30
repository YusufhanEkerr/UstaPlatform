namespace UstaPlatform.Domain.Helpers;

public static class GeoHelper
{
    // Basit mesafe hesaplama (Manhattan mesafesi)
    public static int Distance((int X, int Y) a, (int X, int Y) b)
        => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
}
