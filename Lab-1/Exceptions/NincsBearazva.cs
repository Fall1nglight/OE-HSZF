namespace Lab_1.Exceptions;

public class NincsBearazva : Exception
{
    // fields
    private Termek _termek;

    // constructors
    public NincsBearazva(Termek termek)
        : base()
    {
        _termek = termek;
    }

    // properties
    public Termek Termek => _termek;
}
