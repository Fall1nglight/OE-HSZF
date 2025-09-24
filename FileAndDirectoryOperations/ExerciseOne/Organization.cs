namespace FileAndDirectoryOperations.ExerciseOne;

// szervezeti egység
public class Organization
{
    // fields
    private string _name;
    private List<Person> _persons;

    // constructors
    public Organization(string name)
    {
        _name = name;
        _persons = new List<Person>();
    }

    // methods
    public void AddPerson(Person person) => _persons.Add(person);

    // properties
    public string Name => _name;
}
