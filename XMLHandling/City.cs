using System.Xml.Linq;

namespace XMLHandling;

public class City
{
    // fields
    private string _name;
    private int _population;
    private double _area;
    private string _continent;

    // properties
    public string Name => _name;
    public int Population => _population;
    public double Area => _area;
    public string Continent => _continent;

    // constructors
    public City(string name, int population, double area, string continent)
    {
        _name = name;
        _population = population;
        _area = area;
        _continent = continent;
    }

    public City(XElement xml)
    {
        _name = GetElementValue(xml, "name");

        if (!int.TryParse(GetElementValue(xml, "population"), out int population))
            throw new FormatException("The 'population' attribute is not a valid integer.");

        _population = population;

        if (
            !double.TryParse(
                GetElementValue(xml, "area"),
                System.Globalization.CultureInfo.InvariantCulture,
                out double area
            )
        )
            throw new FormatException("The 'area' attribute is not a valid double.");

        _area = area;

        _continent = GetElementValue(xml, "continent");
    }

    // methods
    private string GetElementValue(XElement xml, string attributeName)
    {
        var attr = xml.Element(attributeName);

        if (attr == null || string.IsNullOrEmpty(attr.Value))
            throw new ArgumentNullException(
                $"{xml.Name} element doesn't have a valid {attributeName} attribute."
            );

        return attr.Value;
    }
}
