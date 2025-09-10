namespace Delegates;

class Program
{
    static void Main(string[] args)
    {
        Examples examples = new Examples();
        examples.RunChapterOne();
        examples.RunChapterTwo();

        Container<string> container = new Container<string>(5);
        container.Add("Jack");
        container.Add("Kate");
        container.Add("John");
        container.Add("Michael");

        container.AddTransformer(x => $"-{x}-");
        container.AddTransformer(x => $"*{x}*");

        // string Upper(string name)
        // {
        //     return name.ToUpper();
        // }
        //
        // container.AddTransformer(Upper);

        container.AddTransformer(x => x.ToUpper());

        container.Traverse(x => Console.WriteLine($"Hi, {x}"));
    }
}
