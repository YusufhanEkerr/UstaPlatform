# UstaPlatform – Şehrin Uzmanlık Platformu
**Ders:** Nesne Yönelimli Programlama (NYP)  
**Amaç:** Arcadia şehrinde vatandaş taleplerini ustalarla eşleştiren, dinamik fiyatlama ve eklenti (plug-in) tabanlı bir sistem geliştirmek.

---

## Proje Özeti
Vatandaş bir talep açtığında:
1. Uygulama uygun ustayı seçer.  
2. Bir iş emri oluşturulur.  
3. Fiyat, **PricingEngine** tarafından hesaplanır.  
4. Usta’nın **Schedule** ve **Route**’una eklenir.  
5. Yeni kurallar (ör. hafta sonu ek ücreti, sadakat indirimi) sadece DLL olarak eklenebilir.

---

##  Proje Yapısı
UstaPlatform.Domain # Temel varlıklar, koleksiyonlar, arayüzler, yardımcılar
UstaPlatform.Pricing # PricingEngine ve BasePriceProvider
UstaPlatform.Infrastructure # InMemory veri depoları
UstaPlatform.Rules.Sample # Örnek fiyat kuralları (DLL olarak çalışır)
UstaPlatform.App # Konsol uygulaması (demo)

---

##  Katmanlar ve Sorumluluklar

| Katman | Görev |
|--------|-------|
| **Domain** | Usta, Vatandaş, Talep, İşEmri nesneleri; Route ve Schedule koleksiyonları |
| **Pricing** | IPricingRule arayüzü, PricingEngine (plug-in yükleme), BasePriceProvider |
| **Infrastructure** | InMemory repository implementasyonları |
| **Rules.Sample** | Örnek fiyat kuralları (Weekend, Emergency, Loyalty) |
| **App** | Tüm sistemi birleştirip demo senaryosunu çalıştırır |

---

##  Plug-in (Eklenti) Sistemi
Yeni kurallar, ana kodu derlemeden çalışır.

1. `IPricingRule` arayüzünü uygula.  
2. DLL olarak derle (ör. `UstaPlatform.Rules.Sample.dll`).  
3. `UstaPlatform.App/bin/Debug/net8.0/plugins` klasörüne kopyala.  
4. Uygulamayı yeniden çalıştır.  

**PricingEngine** bu DLL’i otomatik yükler ve fiyat hesaplamasında uygular.

---

##  Örnek Kurallar
| Kural | Açıklama | Etki |
|-------|-----------|------|
| **WeekendSurchargeRule** | Cumartesi/Pazar günleri ek ücret uygular. | ×1.15 |
| **EmergencyCallRule** | Acil çağrılara sabit ek ücret uygular. | +200₺ |
| **LoyaltyDiscountRule** | 100+ sadakat puanı varsa indirim uygular. | ×0.9 |

---

##  Demo Senaryosu

Hesaplanan fiyat: 500 ₺
1. İlk çalıştırmada:
(Kurallar klasörü boş  sadece taban ücret.)

2. `UstaPlatform.Rules.Sample.dll` dosyasını `plugins` klasörüne kopyala.  
3. Programı yeniden çalıştır:
Hesaplanan fiyat: 450 ₺

(Sadakat indirimi uygulanmış.)

---

##  Kullanılan C# Özellikleri
- **init-only properties** (`init;`)
- **required fields**
- **collection initializer + Add()** (Route sınıfı)
- **Indexer** (Schedule[DateOnly])
- **record struct** (`WorkOrderContext`)
- **Reflection ile dynamic DLL yükleme**
- **SOLID** (SRP, OCP, DIP uygulandı)

---

##  (Opsiyonel) Test Önerileri
- **PricingEngineTests:** Farklı kural kombinasyonlarıyla beklenen fiyat kontrolü.  
- **ScheduleIndexerTests:** Schedule[DateOnly] ile ekleme/okuma testi.

---

##  Derleme ve Çalıştırma
1. `.NET 8.0 SDK` kurulu olmalı.  
2. Solution’u aç → **Build Solution**.  
3. Başlangıç projesi: **UstaPlatform.App**  
4. `Ctrl+F5` ile çalıştır.  
5. `plugins` klasörüne yeni DLL ekleyip tekrar çalıştır.

---


**Ad Soyad:** …  Mohamad Nour ALSALEH
**Numara:** …  16008120089
**Ders:** NYP – UstaPlatform Projesi  
