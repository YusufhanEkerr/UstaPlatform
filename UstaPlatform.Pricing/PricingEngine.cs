using System.Reflection;
using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.Pricing;

public sealed class PricingEngine
{
    private readonly List<IPricingRule> _rules = new();
    private readonly IBasePriceProvider _basePriceProvider;

    public PricingEngine(IBasePriceProvider basePriceProvider)
        => _basePriceProvider = basePriceProvider;

    // Plug-in DLL'leri yükler
    public void LoadRulesFrom(string pluginsFolder)
    {
        if (!Directory.Exists(pluginsFolder)) return;

        foreach (var dll in Directory.EnumerateFiles(pluginsFolder, "*.dll", SearchOption.TopDirectoryOnly))
        {
            var asm = Assembly.LoadFrom(dll);

            foreach (var t in asm.GetTypes()
                                 .Where(t => !t.IsAbstract && typeof(IPricingRule).IsAssignableFrom(t)))
            {
                if (Activator.CreateInstance(t) is IPricingRule rule)
                    _rules.Add(rule);
            }
        }

        // Sıralama (isteğe bağlı)
        _rules.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
    }

    // Fiyat hesaplama (kurallar sırasıyla uygulanır)
    public decimal Calculate(WorkOrderContext ctx)
    {
        decimal price = _basePriceProvider.GetBasePrice(ctx.ServiceType);

        foreach (var rule in _rules)
            price = rule.Apply(price, ctx);

        return Math.Round(price, 2);
    }
}
