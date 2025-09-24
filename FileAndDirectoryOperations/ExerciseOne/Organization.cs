namespace FileAndDirectoryOperations.ExerciseOne;

// szervezeti egység
public class Organization
{
    // fields
    private string _name;
    private List<Person> _persons;

    // constructors
    public Organization()
    {
        _persons = new List<Person>();
    }

    public Organization(string name)
    {
        _name = name;
        _persons = new List<Person>();
    }

    // methods
    public void AddPerson(Person person) => _persons.Add(person);

    public void ParseFromText(string data)
    {
        string[] parts = data.Split('-', StringSplitOptions.RemoveEmptyEntries);
        _name = parts[0];

        for (int i = 1; i < parts.Length; i++)
        {
            Person person = new Person(parts[i]);
            _persons.Add(person);
        }
    }

    // properties
    public string Name => _name;
}
