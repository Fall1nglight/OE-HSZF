using System.Reflection;

namespace Reflection;

class Program
{
    static void Main(string[] args)
    {
        #region Bevezetés

        Dog d = new Dog
        {
            Name = "Baron",
            Age = 3,
            OwnerName = "Jack",
            Color = "white",
        };

        Type t = d.GetType();

        string name1 = t.Name;
        string? name2 = t.FullName;
        string? name3 = t.AssemblyQualifiedName;

        Console.WriteLine($"Típus neve: {name1}");
        Console.WriteLine($"Típus neve, névtérrel : {name2}");
        Console.WriteLine($"Global Assembly Cache értéke: {name3}");

        // származtatási lehetőségek
        Type? baseclass = typeof(Dog).BaseType;
        bool result1 = typeof(Animal).IsAssignableFrom(typeof(Dog));
        bool result2 = typeof(Dog).IsSubclassOf(typeof(Animal));
        bool result3 = typeof(Dog).IsAssignableTo(typeof(IComparable));

        Console.WriteLine();
        Console.WriteLine($"Ősosztály: {baseclass?.Name}");
        Console.WriteLine($"A 'Dog' az 'Animal' leszármazottja: {result1}");
        Console.WriteLine($"A 'Dog' az 'Animal' konkrét leszármazottja: {result2}");
        Console.WriteLine($"A 'Dog'-ot referálhatjuk-e 'IComparable'-vel: {result3}");

        // tulajdonságok kinyerése
        Type t2 = typeof(Dog); // d.getType();
        PropertyInfo? pInfo = t2.GetProperty(nameof(Dog.OwnerName)); // t2.GetProperty("OwnerName");
        PropertyInfo[] pInfos = t2.GetProperties();

        // mezők kinyerése
        FieldInfo? fInfo = t2.GetField(nameof(Dog.Speed)); // t2.GetField("Speed");
        FieldInfo[] fInfos = t2.GetFields();

        // metódusok kinyerése
        MethodInfo? mInfo = t2.GetMethod(nameof(Dog.Bark)); // t2.GetMethod("Bark")
        MethodInfo[] mInfos = t2.GetMethods();
        MethodInfo[] mAllInfos = t2.GetMethods(BindingFlags.NonPublic);

        // tulajdonság típusának ellenőrzése
        if (pInfo?.PropertyType == typeof(string)) { }

        // tulajdonságok / metők értékeinek olvasása vagy írása
        Type t3 = d.GetType();
        PropertyInfo? ownerInfo = t3.GetProperty(nameof(Dog.OwnerName));
        string? name = (string?)ownerInfo?.GetValue(d);
        ;
        ownerInfo?.SetValue(d, "ujNev");
        ;
        List<Dog> dogs = [new Dog { Name = "Baron" }, new Dog { Name = "Marok" }];
        Random rand = new Random();
        ;
        AgeInit(dogs);
        ;

        void AgeInit<T>(IEnumerable<T> items)
        {
            Type type = typeof(T);
            PropertyInfo? propInfo = type.GetProperty("Age");

            foreach (T item in items)
            {
                propInfo?.SetValue(item, rand.Next(0, 100));
            }
        }

        #endregion
    }
}
