using System.Xml.Linq;

namespace XMLHandling;

public class Person
{
    // fields
    private string _name;
    private int _age;
    private string _profession;
    private string _level;
    private Bonus _bonus;

    // properties
    public string Name => _name;
    public int Age => _age;
    public string Profession => _profession;
    public string Level => _level;
    public Bonus Bonus => _bonus;

    // constructors
    public Person(string name, int age, string profession, string level, Bonus bonus)
    {
        _name = name;
        _age = age;
        _profession = profession;
        _level = level;
        _bonus = bonus;
    }

    // methods
    public XElement ToXml()
    {
        return new XElement(
            "person",
            new XElement("name", _name),
            new XElement("age", _age),
            new XElement("profession", _profession),
            new XElement("level", _level),
            _bonus.ToXml()
        );
    }
}
