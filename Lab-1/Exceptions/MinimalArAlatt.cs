namespace Lab_1.Exceptions;

public class MinimalArAlatt : Exception
{
    // fields
    private LicitalhatoTermek _termek;
    private int _minimalAr;

    // constructors
    public MinimalArAlatt(LicitalhatoTermek termek, int minimalAr)
    {
        _termek = termek;
        _minimalAr = minimalAr;
    }

    // properties
    public LicitalhatoTermek Termek => _termek;
    public int MinimalAr => _minimalAr;
}
