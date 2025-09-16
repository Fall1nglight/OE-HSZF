namespace Workshop_1_own;

public class OnStudentDeregisteredEventArgs : EventArgs
{
    // fields
    public Student Student;
    public DateTime Date;

    // constructors
    public OnStudentDeregisteredEventArgs(Student student, DateTime date)
    {
        Student = student;
        Date = date;
    }
}
