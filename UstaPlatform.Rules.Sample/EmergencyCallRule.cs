using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.Rules.Sample;

public sealed class EmergencyCallRule : IPricingRule
{
    public string Name => nameof(EmergencyCallRule);

    public decimal Apply(decimal currentPrice, WorkOrderContext context)
        => context.IsEmergency ? currentPrice + 200m : currentPrice;
}
