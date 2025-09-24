using Lab_1.Interfaces;

namespace Lab_1;

public class MunkaAjanlat : ILicitalhato
{
    // fields
    private int _legjobbAjanlat;

    // constructors
    public MunkaAjanlat(int legjobbAjanlat)
    {
        _legjobbAjanlat = legjobbAjanlat;
    }

    // methods
    public void Licit(int ajanlat)
    {
        if (ajanlat > _legjobbAjanlat)
            _legjobbAjanlat = ajanlat;
    }

    // private void

    // properties
    public int AktualisAr => _legjobbAjanlat;
}
