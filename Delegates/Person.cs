namespace Delegates;

public class Person : IComparable<Person>
{
    // fields
    public string Name { get; set; }
    public int Age { get; set; }
    public string Job { get; set; }

    // constructors
    public Person(string name, int age, string job)
    {
        Name = name;
        Age = age;
        Job = job;
    }

    // methods
    public int CompareTo(Person? other)
    {
        // ha a kapott objektum null, akkor hátrafelé lesz sorolva
        if (other == null)
            return 1;

        int thisAgeNameScore = Age * Name.Length;
        int otherAgeNameScore = other.Age * other.Name.Length;

        // this < other -> -1
        // this > other -> 1
        // this == other -> 0

        if (thisAgeNameScore < otherAgeNameScore)
            return -1;

        if (thisAgeNameScore > otherAgeNameScore)
            return 1;

        return 0;
    }
}
