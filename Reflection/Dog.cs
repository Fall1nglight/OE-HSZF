namespace Reflection;

public class Dog : Animal
{
    public int Speed;

    public string Name { get; set; }
    public int Age { get; set; }
    public string OwnerName { get; set; }
    public string Color { get; set; }

    public void Bark() { }

    private void Eat() { }
}
