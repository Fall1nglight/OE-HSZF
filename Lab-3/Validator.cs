using System.Reflection;

namespace Lab_3;

public static class Validator
{
    public static bool IsValid(Product product)
    {
        Type t = product.GetType();

        var propertiesToCheck = t.GetProperties()
            .Where(pi => pi.GetCustomAttribute<RequiredNonEmptyAttribute>() != null);

        foreach (var info in propertiesToCheck)
        {
            if (info.PropertyType == typeof(string))
            {
                string? value = info.GetValue(product)?.ToString();

                if (string.IsNullOrEmpty(value))
                    return false;
            }
        }

        return true;
    }
}
