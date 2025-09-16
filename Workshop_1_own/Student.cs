namespace Workshop_1_own;

// A hallgató objektum reprezentálja
// a vizsgára jelentkező diákokat
public class Student
{
    // fields
    private string _name;
    private string _neptunCode;

    // constructors
    public Student(string name, string neptunCode)
    {
        _name = name;
        _neptunCode = neptunCode;
    }

    // methods
    /// <summary>
    /// Értesíti a hallgatót, ha regisztrált egy vizsgára
    /// </summary>
    public void NotifyExamRegistration(Exam exam) { }

    /// <summary>
    /// Értesíti a hallgatót, ha törölték a jelenkezését
    /// </summary>
    public void NotifyExamDeregistration(Exam exam) { }

    // properties
    public string Name => _name;

    public string NeptunCode => _neptunCode;
}
