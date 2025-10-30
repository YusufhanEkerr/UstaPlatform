using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.Rules.Sample;

public sealed class LoyaltyDiscountRule : IPricingRule
{
    public string Name => nameof(LoyaltyDiscountRule);

    public decimal Apply(decimal currentPrice, WorkOrderContext context)
        => context.CitizenLoyaltyPoints >= 100 ? currentPrice * 0.90m : currentPrice;
}
