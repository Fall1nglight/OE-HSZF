using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Attributes;

class Program
{
    static void Main(string[] args)
    {
        // Attribútumok lekérése
        Type t = typeof(Dog);
        PropertyInfo? namePropInfo = t.GetProperty(nameof(Dog.Name));
        var attribute = namePropInfo?.GetCustomAttribute<StringLengthAttribute>();
        int? length = attribute?.MaximumLength;

        Console.WriteLine(
            $"A 'Dog' osztály 'Name' tulajdonság 'StringLength' attribútumának az értéke: {length}"
        );

        // többszörös lekérés (ha egy adott 'x' attribútumot többször elhelyezünk)
        var multipleAttributes = namePropInfo?.GetCustomAttributes<StringLengthAttribute>();

        // összes attribútum lekérése
        var attributes = namePropInfo?.GetCustomAttributes();

        List<Dog> dogs =
        [
            new Dog
            {
                Name = "Alex",
                Age = 10,
                Color = "red",
                OwnerName = "Milan",
            },
            new Dog
            {
                Name = "Volk",
                Age = 5,
                Color = "black",
                OwnerName = "Adam",
            },
        ];

        ToTable(dogs);

        ExerciseTwo exerciseTwo = new ExerciseTwo();
        exerciseTwo.Run();

        // példa
        void ToTable<T>(IEnumerable<T> items)
        {
            Type type = typeof(T);

            var displayNames = type.GetProperties()
                .Select(pi => pi.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? "Üres");

            Console.WriteLine(string.Join("\t\t", displayNames));

            foreach (T item in items)
            {
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    Console.Write(property.GetValue(item) + "\t\t");
                }

                Console.WriteLine();
            }
        }
    }
}
