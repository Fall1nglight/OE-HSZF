using System.Xml.Linq;

namespace XMLHandling;

public class Bonus
{
    // fields
    private int _amount;
    private int _frequency;

    // properties
    public int Amount => _amount;
    public int Frequency => _frequency;

    // constructors
    public Bonus(int amount, int frequency)
    {
        _amount = amount;
        _frequency = frequency;
    }

    // methods
    public XElement ToXml() =>
        new XElement(
            "bonus",
            new XElement("amount", _amount),
            new XElement("frequency", _frequency)
        );
}
