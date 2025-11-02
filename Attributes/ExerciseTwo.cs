using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Attributes;

public class ExerciseTwo
{
    public void Run()
    {
        List<Car> cars =
        [
            new Car
            {
                Brand = "BMW",
                Model = "M5",
                Color = "Red",
            },
            new Car
            {
                Brand = "Ford",
                Model = "Focus",
                Color = "Black",
            },
            new Car
            {
                Brand = "Seat",
                Model = "Ibiza",
                Color = "Red-green-black-yellow-purple",
            },
        ];

        List<Car> validCars = Filter(cars);
    }

    private List<T> Filter<T>(IEnumerable<T> items)
    {
        List<T> result = [];
        Type t = typeof(T);
        PropertyInfo[] propInfos = t.GetProperties();

        Dictionary<Type, Func<T, PropertyInfo, Attribute, bool>> rules = new Dictionary<
            Type,
            Func<T, PropertyInfo, Attribute, bool>
        >
        {
            { typeof(LengthAttribute), IsLengthAttributeValid },
            { typeof(StartUpperCaseAttribute), IsStartUpperCaseAttributeValid },
        };

        foreach (T item in items)
        {
            bool isValid = true;

            foreach (PropertyInfo pi in propInfos)
            {
                var attributes = pi.GetCustomAttributes();

                foreach (var attr in attributes)
                {
                    if (rules.ContainsKey(attr.GetType()))
                    {
                        if (!rules[attr.GetType()].Invoke(item, pi, attr))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (!isValid)
                    break;
            }

            if (isValid)
                result.Add(item);
        }

        return result;
    }

    private bool IsLengthAttributeValid<T>(T item, PropertyInfo pi, Attribute attr)
    {
        if (attr is not LengthAttribute lengthAttribute)
            return false;

        int? minLenght = lengthAttribute.MinimumLength;
        int? maxLenght = lengthAttribute.MaximumLength;

        string? value = (string?)pi.GetValue(item);

        if (value?.Length < minLenght.Value || value?.Length > maxLenght.Value)
            return false;

        return true;
    }

    private bool IsStartUpperCaseAttributeValid<T>(T item, PropertyInfo pi, Attribute attr)
    {
        if (attr is not StartUpperCaseAttribute)
            return false;

        string? value = (string?)pi.GetValue(item);

        if (string.IsNullOrEmpty(value) || !char.IsUpper(value[0]))
            return false;

        return true;
    }
}
