namespace FileAndDirectoryOperations;

public class DirectoryHandling
{
    public void Run()
    {
        // 1.0 [Elérési útvonalak]
        // 1.1.0 Útvonalak definiálása
        //      -> .NET 7 verziótol képes értelmezni a program
        //         ezeket a jelöléseket
        string[] lines1 = File.ReadAllLines("files/data.txt");
        string[] lines2 = File.ReadAllLines("./files/data.txt");
        string[] lines3 = File.ReadAllLines(@"files\data.txt");
        string[] lines4 = File.ReadAllLines(@".\files\data.txt");

        // 1.1.1 Path.Combine() használata
        //      -> Legbiztonságosabb megoldás, mert a cél OP rendszer
        //         saját maga építi fel az útvonalat
        string[] lines5 = File.ReadAllLines(
            Path.Combine(Directory.GetCurrentDirectory(), "files", "data.txt")
        );

        // 1.2 Fejlebb lépés
        //      -> FONTOS: sose hivatkozzunk project könyvtárban lévő fájlra,
        //         mivel az nem kerül bele a Release mappába a Build után
        //      -> HOGYHA: olyan programot írunk, amely adatot olvas be egy config fájlból,
        //         akkor azt helyezzük a project mappába és állítsuk be a fájlra, hogy
        //         "Build action" -> "Content" | "Copy to Output" -> "Copy Always"
        //         Így minden buildeléskor bemásolódik a \bin\Debug\netx.0 mappába.
        string[] lines6 = File.ReadAllLines(@"..\..\..\data.txt");

        // 2.0 [Fájlok nevének kinyerése]
        // 2.1.0 Directory.GetFiles() használata
        Console.Write("Enter photo album location: ");
        string path = Console.ReadLine()!;
        string[] fileNames = Directory.GetFiles(path);

        // 2.1.1 Fájlkiterjesztések szűrése
        string[] jpgFileNames = Directory.GetFiles(path, "*.jpg");

        // 3.0 [Mappák nevének kinyerése]
        // 3.1.0 Directory.GetDirectories() használata
        string[] directoryNames = Directory.GetDirectories("...");

        // 3.1.1 Almappák és azok almappáinak kinyerése
        string[] directoryNamesAll = Directory.GetDirectories(
            "files",
            "*",
            SearchOption.AllDirectories
        );
    }
}
