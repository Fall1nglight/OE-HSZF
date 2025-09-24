using System.Text;

namespace FileAndDirectoryOperations;

public class FileHandling
{
    public void Run()
    {
        // 1.0 [Fájl beolvasás]
        // 1.1 fájl sorainak beolvasása egy tömbbe
        string[] lines = File.ReadAllLines("data.txt");

        // 1.2 kódolás megadása
        string[] lines1 = File.ReadAllLines("data.txt", Encoding.UTF8);

        // 1.3 teljes fájl beolvasása
        //      -> hasznos ha keresni akarunk, vagy adott részeket cserélni / módosítani
        string content = File.ReadAllText("data.txt", Encoding.UTF8);

        // 3.0 [Fáljba írás]
        //      -> Ezek a műveletek kivéve az Append(), felülírják a teljes fájl tartalmát.
        // 3.0 sorok kiírása fájlba
        string[] contentToWrite = ["Line1", "Line2", "Line3"];
        File.WriteAllLines("newTxt.txt", contentToWrite, Encoding.UTF8);

        // 3.1 szöveg kiírása fájlba
        string singleContentToWrite = "This is a single line";
        File.WriteAllText("newTxt.txt", singleContentToWrite, Encoding.UTF8);

        // 3.2 szöveg hozzáfűzése fájlhoz
        string contentToAppend = "This is another line";
        File.AppendAllText("newTxt.txt", contentToAppend, Encoding.UTF8);

        // 4.0 [Fájl beolvasás StreamReader használatával]
        //      -> Nem egyszerre olvassa be a fájlt, ezáltal gazdaságosabb a használata,
        //         valamint elkerülhető vele a 'MemoryOutOfRange' kivétel
        // 4.1 StreamReader alapvető használata
        StreamReader sr = new StreamReader("data.txt", Encoding.UTF8);

        while (!sr.EndOfStream)
        {
            Console.WriteLine(sr.ReadLine());
        }

        //  ameddig ezt nem hívjuk meg, a fájlt megnyitva tartja a C# program
        sr.Close();

        // 4.2 StreamReader megfelelőbb használata
        //      -> a 'using' használata lehetővé teszi az sr.Close() elhagyását
        using (StreamReader sr1 = new StreamReader("data.txt", Encoding.UTF8))
        {
            while (!sr1.EndOfStream)
            {
                Console.WriteLine(sr1.ReadLine());
            }
        }

        // 5.0 [Fájlba írás StreamWriter használatával]
        //      -> Ha folyamatosan jönnek az adatok, akkor ezt a megközelítést érdemes használni
        // 5.1 StreamWriter használata
        Random r = new Random();
        using (StreamWriter sw = new StreamWriter("numbers.txt"))
        {
            for (int i = 0; i < 100; i++)
            {
                sw.WriteLine(r.Next(1, 101));
            }
        }

        // 5.2 StreamWriter, hozzáfűzéssel
        StreamWriter sw1 = new StreamWriter("numbers.txt", true, Encoding.UTF8);
    }
}
