namespace UstaPlatform.Domain.Entities;

public sealed class Usta
{
    public Guid Id { get; init; } = Guid.NewGuid();          // init-only
    public DateTime KayitZamani { get; init; } = DateTime.UtcNow; // init-only

    public required string Ad { get; init; }      // required + init
    public required string Uzmanlik { get; init; } // "Tesisat", "Elektrik"...
    public double Puan { get; set; }
    public int GuncelYuk { get; set; }
}
