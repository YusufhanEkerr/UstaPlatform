namespace UstaPlatform.Pricing;

public interface IBasePriceProvider
{
    decimal GetBasePrice(string serviceType);
}

public sealed class SimpleBasePriceProvider : IBasePriceProvider
{
    private readonly Dictionary<string, decimal> _map = new()
    {
        ["Tesisat"] = 900,
        ["Elektrik"] = 550,
        ["Marangoz"] = 600
    };

    public decimal GetBasePrice(string serviceType)
        => _map.TryGetValue(serviceType, out var v) ? v : 350;
}
