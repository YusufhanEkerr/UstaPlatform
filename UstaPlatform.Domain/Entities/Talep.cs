namespace UstaPlatform.Domain.Entities;

public sealed class Talep
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime KayitZamani { get; init; } = DateTime.UtcNow;

    public required string Aciklama { get; init; }
    public required string ServisTuru { get; init; }
    public required string Konum { get; init; }
    public DateTime TalepZamani { get; init; } = DateTime.Now;
    public bool AcilMi { get; init; }
}
