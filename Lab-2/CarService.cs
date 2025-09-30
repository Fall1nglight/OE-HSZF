using System.Text;
using Lab_2.Events;

namespace Lab_2;

public class CarService
{
    public List<Car> Cars { get; set; }
    public event EventHandler<CarBrandEventArgs> CarBrand;

    public CarService() { }

    public void ParseFromFile(string fileName)
    {
        // létrehozunk egy üres listát
        Cars = new List<Car>();

        // ellenőrizzük, hogy a fájl létezik-e
        // ha nem hibát dobunk
        if (!File.Exists(fileName))
            throw new FileNotFoundException(fileName);

        // beolvassuk soronként egy tömbbe az autók adatait
        string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

        // üres fájl esetén hibát dobunk
        if (lines.Length == 0)
            throw new Exception("Empty file");

        // bejárjuk a tömb elemeit
        foreach (var line in lines)
        {
            // minden sorból készítünk egy Car objektumot
            // és hozzáadjuk a listához
            string[] parts = line.Split(';');

            string brand = parts[0];
            string model = parts[1];

            // kezeljük a parszolási hibákat
            if (!int.TryParse(parts[2], out int year))
                throw new Exception("Year must be an integer");

            if (!int.TryParse(parts[3], out int price))
                throw new Exception("Price must be an integer");

            Cars.Add(new Car(brand, model, year, price));
        }

        // miután beolvastuk az összes autót a fájéból
        // csoportotsítjuk őket a márkákjuk alapján
        var brands = Cars.GroupBy(car => car.Brand);

        // bejárjuk a csoportokat
        foreach (var grouping in brands)
        {
            // minden csoport kivált egy Event-et, amely tartalmazza az adott márkát és a belőle beolvasott darabszámot
            CarBrand?.Invoke(this, new CarBrandEventArgs(grouping.Key, grouping.Count()));
        }
    }
}
