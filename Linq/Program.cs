using System.Xml.Schema;

namespace Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Student> groupA = new List<Student>()
        {
            new Student("John", 180, 3),
            new Student("Mark", 191, 4),
            new Student("Josh", 162, 5),
        };

        List<Student> groupB = new List<Student>()
        {
            new Student("John", 180, 3),
            new Student("David", 159, 3),
            new Student("Milan", 167, 4),
        };

        // Első feladat
        var metszet = groupA.Intersect(groupB);
        var unio = groupA.Union(groupB);
        var kulonbseg = groupA.Except(groupB);

        // Második feladat
        var students = unio.ToList();
        var hasHeigherThan180 = students.Any(s => s.Height > 180);
        var noneFailed = students.All(s => s.Mark > 1);
        var betterThanMark3 = students.Where(s => s.Mark > 3);
        var heigherThan170Count = students.Count(s => s.Height > 170);

        // var bestMark = students.OrderBy(s => s.Mark).Select(s => s.Mark).First();
        var bestMark = students.Max(s => s.Mark);
        var bestStudents = students.Where(s => s.Mark == bestMark);

        var top3Students = students.OrderByDescending(s => s.Mark).Take(3);
        var top3StudentNames = students.OrderByDescending(s => s.Name).Take(3).Select(s => s.Name);
    }
}
