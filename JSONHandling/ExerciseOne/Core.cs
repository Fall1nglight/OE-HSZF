using Newtonsoft.Json;

namespace JSONHandling.ExerciseOne;

public class Core
{
    public void Run()
    {
        // Két JSON fájl áll rendelkezésünkre.
        // Az egyikben a dolgozók találhatóak névvel, fizetéssel, munkakörrel és a szervezeti egységükkel.
        // A másikban a szervezeti egységek és a város, ahol találhatóak.
        // Olvassuk be a két JSON fájlt objektumgyűjteménybe!

        var departments = JsonConvert.DeserializeObject<List<Dept>>(
            File.ReadAllText("departments.json")
        );

        var workers = JsonConvert.DeserializeObject<List<Worker>>(File.ReadAllText("workers.json"));

        // A két adatforráson végezzünk el JOIN-t a deparment alapján! Végezzük el az alábbi lekérdezést:

        if (departments == null || workers == null)
            return;

        var join = workers.Join(
            departments,
            worker => worker.Department,
            dept => dept.Department,
            (worker, dept) => new { Department = dept, Worker = worker }
        );

        // Városonként mekkora az átlagfizetés és hányan dolgoznak ott?
        // Az eredményt egy típusos gyűjteményként kérjük  le, majd szerializáljuk JSON fájlba!
        var group = join.GroupBy(x => x.Department.Location)
            .Select(x => new GroupResult
            {
                City = x.Key,
                AvgSalary = x.Average(y => y.Worker.Salary),
                NumOfWorkers = x.Count(),
            });

        string output = JsonConvert.SerializeObject(group);
        File.WriteAllText("output.json", output);
    }
}
