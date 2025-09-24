namespace FileAndDirectoryOperations;

public class OperationExamples
{
    public void Run()
    {
        // 1.0 [Fájl- és könyvtárműveletek]
        //      -> Ezek a metódusok a fájlokat és könyvtárakat hoznak létre, másolnak, mozgatnak, törölnek, vagy információt kérdeznek le róluk.

        // 1.1 Fájl és könyvtár létrehozása
        //      -> A 'File.Create' üres fájlt hoz létre. Általában nincs rá szükség, mert a 'File.WriteAllText' is létrehozza a fájlt, ha még nem létezik.
        File.Create("data.txt");
        //      -> A 'Directory.CreateDirectory' létrehozza a megadott könyvtárat, ha az még nem létezik. Fontos, mert a fájl műveletek hibát dobnak, ha a célkönyvtár hiányzik.
        Directory.CreateDirectory("files");

        // 1.2 Fájl és könyvtár létezésének ellenőrzése
        //      -> A 'File.Exists' metódus ellenőrzi, hogy egy adott fájl létezik-e.
        bool fileExists = File.Exists("data.txt");
        Console.WriteLine($"A 'data.txt' fájl létezik: {fileExists}");

        //      -> A 'Directory.Exists' metódus ellenőrzi, hogy egy adott könyvtár létezik-e.
        bool directoryExists = Directory.Exists("files");
        Console.WriteLine($"A 'files' könyvtár létezik: {directoryExists}");

        // 1.3 Fájl áthelyezése és átnevezése
        //      -> A 'File.Move' metódus áthelyezi a fájlt egy új helyre, és egyben át is nevezheti.
        //         A 'Path.Combine' a platformtól függetlenül hoz létre érvényes útvonalat.
        File.Move("data.txt", Path.Combine(Directory.GetCurrentDirectory(), "files", "mydata.txt"));

        // 1.4 Fájl másolása
        //      -> A 'File.Copy' metódus lemásolja a fájlt. Lehetőség van új nevet is megadni a másolatnak.
        File.Copy(
            "mydata.txt",
            Path.Combine(Directory.GetCurrentDirectory(), "files", "copied_data.txt")
        );

        // 1.5 Könyvtár áthelyezése
        //      -> A 'Directory.Move' áthelyezi az egész könyvtárat a tartalmával együtt.
        //         Könyvtár másolás közvetlenül nem lehetséges, azt rekurzív módon kell megvalósítani.
        Directory.Move("files", Path.Combine(Directory.GetCurrentDirectory(), "backup", "files"));

        // 1.6 Fájl és könyvtár attribútumainak lekérdezése
        //      -> A 'File.Get...' metódusok a fájl metaadatokat adják vissza.
        DateTime fileCreationTime = File.GetCreationTime("mydata.txt");
        DateTime fileLastAccessTime = File.GetLastAccessTime("mydata.txt");
        DateTime fileLastWriteTime = File.GetLastWriteTime("mydata.txt");

        Console.WriteLine($"A 'mydata.txt' fájl adatai:");
        Console.WriteLine($"  - Létrehozva: {fileCreationTime}");
        Console.WriteLine($"  - Utolsó hozzáférés: {fileLastAccessTime}");
        Console.WriteLine($"  - Utolsó írás: {fileLastWriteTime}");

        //      -> A 'Directory.Get...' metódusok a könyvtár metaadatait adják vissza.
        DateTime dirCreationTime = Directory.GetCreationTime("backup");
        DateTime dirLastAccessTime = Directory.GetLastAccessTime("backup");
        DateTime dirLastWriteTime = Directory.GetLastWriteTime("backup");

        Console.WriteLine($"A 'backup' könyvtár adatai:");
        Console.WriteLine($"  - Létrehozva: {dirCreationTime}");
        Console.WriteLine($"  - Utolsó hozzáférés: {dirLastAccessTime}");
        Console.WriteLine($"  - Utolsó írás: {dirLastWriteTime}");
    }
}
