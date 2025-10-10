using System.Xml.Linq;

namespace XMLHandling;

public class Department
{
    // fields
    private string _name;
    private string _location;
    private List<Person> _employees;

    // properties
    public string Name => _name;
    public string Location => _location;
    public List<Person> Employees => _employees;

    // constructors
    public Department(string name, string location, List<Person>? employees)
    {
        _name = name;
        _location = location;
        _employees = employees ?? [];
    }

    // methods
    public XElement ToXml()
    {
        return new XElement(
            "department",
            new XElement("name", _name),
            new XElement("location", _location),
            _employees.Select(emp => emp.ToXml())
        );
    }
}
