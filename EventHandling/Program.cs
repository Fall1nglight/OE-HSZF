namespace EventHandling;

class Program
{
    static void Main(string[] args)
    {
        MatrixStorage<string> matrixStorage = new MatrixStorage<string>(3, 3);

        matrixStorage.ColumnFull += (obj, evArgs) =>
            Console.WriteLine(
                $"Megtelet a(z) {evArgs.Index}. oszlop a [{evArgs.Item}] beszúrása után."
            );

        matrixStorage.RowFull += (obj, evArgs) =>
            Console.WriteLine(
                $"Megtelet a(z) {evArgs.Index}. sor a [{evArgs.Item}] beszúrása után."
            );

        matrixStorage.MatrixFull += () => Console.WriteLine("A mátrix betelet.");

        matrixStorage.Add("Teszt0");
        matrixStorage.Add("Teszt1");
        matrixStorage.Add("Teszt2");
        matrixStorage.Add("Teszt3");
        matrixStorage.Add("Teszt4");
        matrixStorage.Add("Teszt5");
        matrixStorage.Add("Teszt6");
        ;
    }
}
