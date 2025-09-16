namespace Workshop_1_own;

public class OnStudentRegisteredEventArgs : EventArgs
{
    // fields
    public Student Student;
    public DateTime Date;

    // constructors
    public OnStudentRegisteredEventArgs(Student student, DateTime date)
    {
        Student = student;
        Date = date;
    }
}
