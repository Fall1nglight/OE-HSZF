namespace Workshop_1_own;

// Ez az osztály egy egyetemi vizsgát kezel
public class Exam
{
    // fields
    private string _subject;
    private DateTime _date;
    private int _maxSeats;
    private List<Student> _students;
    private Func<Student, bool> _preJoinDelegate;

    // events
    public event EventHandler<OnStudentRegisteredEventArgs> OnStudentRegistered;
    public event EventHandler<OnStudentDeregisteredEventArgs> OnStudentDeregistered;

    // constructors
    public Exam(string subject, DateTime date, int maxSeats)
    {
        _subject = subject;
        _date = date;
        _maxSeats = maxSeats;
        _students = new List<Student>();
    }

    // ! kelleni fog még konstruktor

    // methods
}
