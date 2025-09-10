using System.ComponentModel;

namespace Delegates;

public class Examples
{
    // fields
    delegate void Greeter(string name);
    delegate double MathDelegate(double a, double b);

    // constructors

    // methods
    void HungarianGreeter(string name)
    {
        Console.WriteLine($"Szia, {name}");
    }

    void EnglishGreeter(string name)
    {
        Console.WriteLine($"Hi, {name}");
    }

    double Add(double a, double b)
    {
        return a + b;
    }

    double Mul(double a, double b)
    {
        return a * b;
    }

    int DateComparer(DateTime a, DateTime b)
    {
        return a.Second.CompareTo(b.Second);
    }

    bool YoungerThan30(Person person) => person.Age < 30;

    public void RunChapterOne()
    {
        // A delegáltak olyan típusbiztos függvénytárgyak, amelyek több metódusra is hivatkozhatnak.
        // Létrehozhatunk egy delegált példányt, ami egy vagy több függvényre "mutat".

        // 1. Delegált létrehozása és függvények hozzáadása
        // A Greeter delegált egy olyan függvényre mutathat, amely egy 'string' típusú paramétert vár, és nem ad vissza értéket (void).
        Greeter greeterFunction = HungarianGreeter;
        greeterFunction += EnglishGreeter;

        // A delegált "láncban" lévő függvények meghívása.
        // Fontos a null-ellenőrzés (a `?.` operátorral), ami megakadályozza a `NullReferenceException` hibát,
        // ha a delegált nem mutat egyetlen függvényre sem.
        greeterFunction?.Invoke("Pál"); // Meghívja a HungarianGreeter-t, majd az EnglishGreeter-t.

        // 2. Visszatérési értékkel rendelkező delegáltak működése
        // A MathDelegate delegált olyan függvényekre hivatkozik, amelyek két 'double' paramétert várnak, és 'double'-lel térnek vissza.
        MathDelegate mathDelegate = Add;
        mathDelegate += Mul;

        // Több függvény meghívása egy delegálton keresztül.
        // Fontos tudni, hogy a delegált láncban az utolsó hozzáadott függvény visszatérési értéke lesz a delegált hívásának végső eredménye.
        // A korábbi függvények eredménye elveszik.

        double finalMathResult = mathDelegate(3.5, 4.5);
        Console.WriteLine($"Az utolsó meghívott delegált értéke: {finalMathResult}"); // A Mul függvény eredménye (15.75) íródik ki.

        // 3. A delegált lánc elemeinek bejárása és az összes eredmény kinyerése
        // A GetInvocationList() metódus visszaadja a delegált láncban lévő összes függvényt egy tömbben.
        // Így egyenként is meghívhatjuk őket, és eltárolhatjuk az eredményeket.
        List<double> allResults = new List<double>();

        foreach (var item in mathDelegate.GetInvocationList())
        {
            double? iterationResult = (item as MathDelegate)?.Invoke(3.5, 4.5);

            if (iterationResult.HasValue)
                allResults.Add(iterationResult.Value);
        }

        // Az összes eredmény megjelenítése
        Console.WriteLine($"Az összes delegált eredménye: {string.Join(", ", allResults)}"); // Eredmény: 8, 15.75
    }

    public void RunChapterTwo()
    {
        // Beépített delegáltak
        // void() => Action | MethodInvoker
        // void (a) => Action<a>
        // void(a,b,...,p) => Action<a,b,...,p> (max 16 paraméter)

        // r(a) => Func<a, r>
        // r(a,b) => Func<a,b,r>
        // r(a,b,...,p) => Func<a,b,...,p> (max 16 paraméter)

        // bool(T) => Predicate<T>
        // int(T,T) => Comparison<T>

        // Most megvalósítjuk az előző fejezetben használt delegáltakat beépített delegáltakkal
        Func<double, double, double> mathFunctions = Add;
        mathFunctions += Mul;

        // Példának okáért létrehozunk egy listát, amiben személyeket (egyszerű objektumokat) tárolunk
        List<Person> people =
        [
            new Person("John", 44, "ceo"),
            new Person("Jack", 33, "lead developer"),
            new Person("Sarah", 35, "UX designer"),
            new Person("Kate", 28, "frontend developer"),
            new Person("Michael", 20, "trainee"),
        ];

        // Számtalan olyan függvény létezik, amely utólag megírt logikát vár tőlünk
        // pl.: FindAll() | Predicate<T> delegáltat vár tőlünk
        // Ez a háttérben így néz ki FindAll(Predicate<T> match) ...
        List<Person> youngsters = people.FindAll(YoungerThan30);

        DateTime[] dates =
        {
            DateTime.Parse("2022.10.23 12:34:23"),
            DateTime.Parse("2021.02.11 08:10:53"),
            DateTime.Parse("2023.05.27 22:31:37"),
            DateTime.Parse("2020.01.02 10:00:01"),
            DateTime.Parse("2021.12.24 18:20:30"),
        };

        // Rendezzük a dátumokat növekvő sorrendbe a beépített Array.Sort() metódussal
        Array.Sort(dates);

        // Mi van abban az esetben ha az alapján akarjuk őket rendezni, hogy hol kisebb a másodperc értéke?
        // (nyílván ennek semmi értelme)

        Array.Sort(dates, DateComparer);

        // Outer Variable Trap

        Action numWriter = null!;

        for (int i = 0; i < 10; i++)
        {
            numWriter += () =>
            {
                Console.WriteLine(i);
            };
        }

        //Az eredmény:  10,10,10..... lesz.
        numWriter();

        // A lambdában felhasznált külső változó címként adódík át
        // lehetséges megoldás: létrehozunk egy változót, amibe érték szerint
        // átmásoljuk a külső változó értéket és ezt adjuk át a lambdának

        Action szamkiiro = null!;

        for (int i = 0; i < 10; i++)
        {
            int k = i;

            szamkiiro += () =>
            {
                Console.WriteLine(k);
            };
        }

        // Az eredmény: 0,1,2,3..... lesz.
        szamkiiro();
    }
}
