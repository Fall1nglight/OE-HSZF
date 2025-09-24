using FileAndDirectoryOperations.ExerciseOne;
using FileAndDirectoryOperations.ExerciseTwo;

namespace FileAndDirectoryOperations;

class Program
{
    static void Main(string[] args)
    {
        Core core = new Core("input.txt");
        RecursiveExplorer explorer = new RecursiveExplorer("Egyetem\\", 5);
    }
}
