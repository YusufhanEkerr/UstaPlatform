using System.Globalization;

namespace UstaPlatform.Domain.Helpers;

public static class MoneyFormatter
{
    public static string Format(decimal amount, string culture = "tr-TR")
        => string.Format(new CultureInfo(culture), "{0:C}", amount);
}
