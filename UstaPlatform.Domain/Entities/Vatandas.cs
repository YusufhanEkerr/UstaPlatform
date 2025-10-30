namespace UstaPlatform.Domain.Entities;

public sealed class Vatandas
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime KayitZamani { get; init; } = DateTime.UtcNow;

    public required string AdSoyad { get; init; }
    public required string Adres { get; init; }
    public int LoyaltyPoints { get; set; }
}
