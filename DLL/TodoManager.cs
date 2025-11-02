using System.Runtime.InteropServices;
using System.Text;

namespace DLL;

public class TodoManager
{
    // Készítsünk egy alkalmazást, amely megjelenít egy teendő listát!
    // Legyünk képesek a végére újabb teendőket felvinni
    // Üres felvitel esete jelentse a program végét
    // A program ekkor egy felugró MessageBox segítségével kérdezze meg, hogy szeretnénk-e menteni

    public List<string> Todos { get; set; }

    private string _fileName;

    public TodoManager(string fileName)
    {
        _fileName = fileName;

        if (!File.Exists(_fileName))
            File.Create(_fileName).Close();

        Todos = File.ReadAllLines(_fileName, Encoding.UTF8).ToList();
    }

    public void Open()
    {
        ShowTodos();
        PrompForNewTodos();
        PromptForSave();
    }

    private void ShowTodos()
    {
        Console.WriteLine("===Todos===");

        for (int i = 0; i < Todos.Count; i++)
            Console.WriteLine($"[{i + 1}] {Todos[i]}");
    }

    private void PrompForNewTodos()
    {
        string newTodo;

        do
        {
            Console.Write("Add new todo: ");
            newTodo = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(newTodo))
                Todos.Add(newTodo);
        } while (!string.IsNullOrWhiteSpace(newTodo));
    }

    private void PromptForSave()
    {
        // char[] validInputs = ['y', 'n'];
        // char input;
        //
        // do
        // {
        //     Console.Write("Would you like to save? (y/n): ");
        //     input = Console.ReadKey().KeyChar;
        //
        //     Console.WriteLine();
        // } while (!validInputs.Contains(input));
        //
        // if (input == 'y')
        //     File.WriteAllLines(_fileName, Todos, Encoding.UTF8);
        int result = MessageBox(
            0,
            "Would you like to save the changes before exiting?",
            "Mentés",
            1
        );

        if (result == 1)
            File.WriteAllLines(_fileName, Todos, Encoding.UTF8);
    }

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr hwnd, string text, string caption, int type);
}
