using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.Rules.Sample;

public sealed class WeekendSurchargeRule : IPricingRule
{
    public string Name => nameof(WeekendSurchargeRule);

    public decimal Apply(decimal currentPrice, WorkOrderContext context)
        => (context.When.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            ? currentPrice * 1.15m
            : currentPrice;
}
