namespace UstaPlatform.Domain.Interfaces;

public interface IPricingRule
{
    string Name { get; }
    decimal Apply(decimal currentPrice, WorkOrderContext context);
}

public sealed record WorkOrderContext(
    DateTime When,
    string Neighborhood,
    bool IsEmergency,
    int CitizenLoyaltyPoints,
    string ServiceType
);
