namespace UstaPlatform.Domain.Helpers;

public static class Guard
{
    public static void AgainstNull(object? obj, string name)
    {
        if (obj is null)
            throw new ArgumentNullException(name);
    }

    public static void AgainstNegative(decimal value, string name)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(name);
    }
}
