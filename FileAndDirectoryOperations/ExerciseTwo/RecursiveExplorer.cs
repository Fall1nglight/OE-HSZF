namespace FileAndDirectoryOperations.ExerciseTwo;

public class RecursiveExplorer
{
    // fields
    private string _path;
    private int _depth;
    private List<string> _files;

    // constructors
    public RecursiveExplorer(string path, int depth)
    {
        _path = path;
        _depth = depth;
        _files = new List<string>();

        Init();
    }

    // methods
    private void Init()
    {
        GetFiles(_path, 0, _depth);
    }

    private void GetFiles(string path, int currDepth, int targetDepth)
    {
        // ha elérjük a kívánt mélységet, visszatérünk
        if (currDepth == targetDepth)
            return;

        // meghatározzuk a tabulátor méretét a mélyéség alapján
        // és kiírjuk a jelenlegi elérési címet
        string directoryTab = new string('\t', currDepth);
        Console.WriteLine($"{directoryTab}{path}");

        // kiolvassuk a fájlokat a jelnlegi könyvtárból
        foreach (var fileName in Directory.GetFiles(path))
        {
            // meghatározzuk a tabulátor méretét a mélység alapján
            string fileTab = new string('\t', currDepth + 1);

            // formázzuk a fájlneveket, hogy ne legyen redundáns a kiírás
            // és kiírjuk azokat
            string formattedFileName = fileTab + fileName.Replace(path, string.Empty);
            Console.WriteLine(formattedFileName);
        }

        // sortörés, hogy átláthatóbb legyen a kiírás
        Console.WriteLine();

        // bejárjuk a könyvtárban található almappákat
        foreach (var directory in Directory.GetDirectories(path))
        {
            // minden almappára meghívjuk rekurzívan a függvényt, növelve a mélységet
            GetFiles(directory, currDepth + 1, targetDepth);
        }
    }

    // properties
}
