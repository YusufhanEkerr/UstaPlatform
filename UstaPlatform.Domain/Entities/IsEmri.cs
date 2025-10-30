using UstaPlatform.Domain.Collections;

namespace UstaPlatform.Domain.Entities;

public sealed class IsEmri
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime KayitZamani { get; init; } = DateTime.UtcNow;

    public required Vatandas Sahip { get; init; }
    public required Usta AtananUsta { get; init; }
    public required Talep KaynakTalep { get; init; }

    public decimal TabanUcret { get; init; }
    public decimal HesaplananUcret { get; set; }

    public DateTime Baslangic { get; init; }
    public TimeSpan TahminiSure { get; init; }

    // 🔹 Eksik olan özellik buydu:
    public Route? RotaDuragi { get; set; }
}
