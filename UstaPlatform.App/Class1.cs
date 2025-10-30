using UstaPlatform.Domain.Entities;
using UstaPlatform.Domain.Interfaces;
using UstaPlatform.Domain.Collections;
using UstaPlatform.Infrastructure.Repositories;
using UstaPlatform.Pricing;

// ---- Plugins klasörü ----
var plugins = Path.Combine(AppContext.BaseDirectory, "plugins");
Directory.CreateDirectory(plugins);

// ---- Ustalar ----
var ustalar = new List<Usta>
{
    new() { Ad = "Fatma Usta", Uzmanlik = "Tesisat", Puan = 4.8, GuncelYuk = 1 },
    new() { Ad = "Ahmet Usta", Uzmanlik = "Tesisat", Puan = 4.5, GuncelYuk = 0 }
};

var ustaRepo = new InMemoryUstaRepository(ustalar);
var woRepo = new InMemoryWorkOrderRepository();

// ---- Vatandaş ve Talep ----
var vatandas = new Vatandas { AdSoyad = "Elif Yılmaz", Adres = "Mahalle A", LoyaltyPoints = 120 };
var talep = new Talep
{
    Aciklama = "Mutfakta su sızıntısı var",
    ServisTuru = "Tesisat",
    Konum = "(1,1)",
    AcilMi = false
};

// ---- Basit eşleştirme: en az iş yükü olan usta ----
var adaylar = ustaRepo.GetByExpertise(talep.ServisTuru);
var secilen = adaylar.OrderBy(u => u.GuncelYuk).ThenByDescending(u => u.Puan).First();

// ---- İş emri oluştur ----
var isEmri = new IsEmri
{
    Sahip = vatandas,
    AtananUsta = secilen,
    KaynakTalep = talep,
    TabanUcret = 0,
    Baslangic = DateTime.Now.AddHours(2),
    TahminiSure = TimeSpan.FromHours(1.5),
    RotaDuragi = new Route { { 1, 1 }, { 2, 1 } }
};

// ---- Fiyat motoru ----
var baseProvider = new SimpleBasePriceProvider();
var engine = new PricingEngine(baseProvider);
engine.LoadRulesFrom(plugins);

var ctx = new WorkOrderContext(
    When: isEmri.Baslangic,
    Neighborhood: vatandas.Adres,
    IsEmergency: talep.AcilMi,
    CitizenLoyaltyPoints: vatandas.LoyaltyPoints,
    ServiceType: talep.ServisTuru);

isEmri.HesaplananUcret = engine.Calculate(ctx);
woRepo.Add(isEmri);

// ---- Sonuç ----
Console.WriteLine("=== UstaPlatform Demo ===");
Console.WriteLine($"Usta: {secilen.Ad}");
Console.WriteLine($"Talep: {talep.Aciklama}");
Console.WriteLine($"Hesaplanan fiyat: {isEmri.HesaplananUcret} ₺");
Console.WriteLine();
Console.WriteLine($"Kurallar klasörü: {plugins}");
Console.WriteLine("Bu klasöre yeni bir kural DLL (örn. LoyaltyDiscountRule.dll) kopyalayın ve uygulamayı yeniden çalıştırın.");
