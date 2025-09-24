using Lab_1.Exceptions;
using Lab_1.Interfaces;

namespace Lab_1;

public class LicitalhatoTermek : Termek, ILicitalhato
{
    // fields
    protected int _minimalAr;

    // constructors
    public LicitalhatoTermek(string nev, int minimalAr)
        : base(nev) { }

    // methods
    public void Licit(int ajanlat)
    {
        if (ajanlat > AktualisAr)
        {
            // uj ar felvetele
            Arvaltozas(ajanlat);
        }
    }

    private int GetAktualisAr()
    {
        if (_arIdx == 0)
            return 0;

        return _arak[_arIdx - 1];
    }

    // properties
    public override int MinimalAr
    {
        get
        {
            int szamitottAr = base.MinimalAr;

            if (szamitottAr < _minimalAr)
                throw new MinimalArAlatt(this, _minimalAr);

            return szamitottAr;
        }
    }

    public int AktualisAr => GetAktualisAr();
}
