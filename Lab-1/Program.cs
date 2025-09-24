using Lab_1.Interfaces;

namespace Lab_1;

class Program
{
    static void Main(string[] args)
    {
        Termek[] termekek = new Termek[5];

        Termek kuka = new Termek("Kuka");
        kuka.Arvaltozas(1);

        Termek eger = new Termek("Egér");
        eger.Arvaltozas(2);

        Termek billentyuzet = new Termek("Billentyűzet");
        LicitalhatoTermek kabel = new LicitalhatoTermek("Kábel", 1000);
        LicitalhatoTermek konnektor = new LicitalhatoTermek("Konnektor", 2000);

        termekek[0] = kuka;
        termekek[1] = eger;
        termekek[2] = billentyuzet;
        termekek[3] = kabel;
        termekek[4] = konnektor;

        // minimál ár keresés
        int maxIdx = 0;

        for (int i = 1; i < termekek.Length; i++)
        {
            try
            {
                if (termekek[i].MinimalAr > termekek[maxIdx].MinimalAr)
                    maxIdx = i;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba történt minimál ár keresés közben: {e.Message}");
            }
        }

        Console.WriteLine($"Legmagasabb minimál ár => {termekek[maxIdx].Nev}");

        // ILicitálható termékek
        ILicitalhato[] licitalhato = new ILicitalhato[5];
        int licitalhatoIdx = 0;

        for (int i = 0; i < termekek.Length; i++)
        {
            Termek? item = termekek[i];

            if (item is null)
                continue;

            if (item is LicitalhatoTermek)
            {
                licitalhato[licitalhatoIdx++] = termekek[i] as LicitalhatoTermek;
            }
        }

        MunkaAjanlat ajanlat1 = new MunkaAjanlat(3000);
        MunkaAjanlat ajanlat2 = new MunkaAjanlat(1000);
        MunkaAjanlat ajanlat3 = new MunkaAjanlat(6000);
        licitalhato[2] = ajanlat1;
        licitalhato[3] = ajanlat2;
        licitalhato[4] = ajanlat3;

        int arValtozasDb = 0;
        for (int i = 0; i < licitalhato.Length; i++)
        {
            ILicitalhato item = licitalhato[i];
            int eredetiAr = item.AktualisAr;

            item.Licit(1000);

            if (item.AktualisAr != eredetiAr)
                arValtozasDb++;
        }

        Console.WriteLine($"{arValtozasDb} árváltozás történt.");
        ;
    }
}
