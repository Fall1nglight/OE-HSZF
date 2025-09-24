using Lab_1.Exceptions;

namespace Lab_1;

public class Termek
{
    // fields
    protected string _nev;
    protected int[] _arak;
    protected int _arIdx;

    // constructors
    public Termek(string nev)
    {
        _nev = nev;
        _arak = new int[10];
    }

    // methods
    public void Arvaltozas(int ujAr)
    {
        // ha tele van a tömb
        // töröljük a legrégebbi árat
        if (_arIdx == _arak.Length)
            _arIdx = 0;

        _arak[_arIdx++] = ujAr;
    }

    // properties
    public string Nev => _nev;

    public virtual int MinimalAr
    {
        get
        {
            if (_arIdx == 0)
                throw new NincsBearazva(this);

            int minIdx = 0;

            for (int i = 1; i < _arak.Length && _arak[i] != 0; i++)
            {
                if (_arak[i] < _arak[minIdx])
                    minIdx = i;
            }

            return _arak[minIdx];
        }
    }
}
