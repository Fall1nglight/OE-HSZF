namespace DLL;

class Program
{
    static void Main(string[] args)
    {
        TodoManager todoManager = new TodoManager("todos.txt");
        todoManager.Open();
    }
}
