namespace Linq;

public class Student
{
    // fields
    private string _name;
    private int _height;
    private int _mark;

    // properties
    public string Name => _name;

    public int Height => _height;

    public int Mark => _mark;

    // constructors
    public Student(string name, int height, int mark)
    {
        _name = name;
        _height = height;
        _mark = mark;
    }

    // methods
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        var other = obj as Student;

        if (other == null)
            throw new ArgumentNullException(nameof(obj), "Cannot compare null values.");

        return Name.Equals(other.Name) && Height == other.Height && Mark == other.Mark;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Height, Mark);
    }
}
