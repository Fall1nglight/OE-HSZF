using System.Xml.Linq;

namespace XMLHandling;

class Program
{
    static void Main(string[] args)
    {
        #region Első feladat

        XDocument cityDoc = XDocument.Load("cities.xml");

        if (cityDoc.Root == null)
            throw new ArgumentNullException($"{cityDoc.Root} must have a root element.");

        List<City> cities = cityDoc.Root.Elements("city").Select(city => new City(city)).ToList();

        // Egy LINQ lekérdezés segítségével állapítsuk meg minden földrészre a benne található városok számát, átlagos területét és lakosságát!
        // Az eredményt típusos gyűjteménykét kezeljük és mentsük el XML fájlba!

        var grouping = cities
            .GroupBy(city => city.Continent)
            .Select(group => new
            {
                Continet = group.Key,
                CityCount = group.Count(),
                AvgArea = group.Average(city => city.Area),
                AvgPopulation = group.Average(city => city.Population),
            });

        // kiírás fájlba
        XDocument groupingDoc = new XDocument();
        XElement groupingRoot = new XElement("groupings");
        groupingDoc.Add(groupingRoot);

        groupingRoot.Add(
            grouping.Select(group => new XElement(
                "continent",
                new XElement("name", group.Continet),
                new XElement("city_count", group.CityCount),
                new XElement("avg_area", group.AvgArea),
                new XElement("avg_population", group.AvgPopulation)
            ))
        );

        groupingDoc.Save("groupings.xml");
        #endregion

        // adatok további műveletvégzéshez
        List<Department> departments = new List<Department>
        {
            new Department(
                "HQ",
                "Dallas",
                new List<Person>
                {
                    new Person("Paul", 32, "ceo", "ceo", new Bonus(5000, 12)),
                    new Person("Michael", 40, "a/b tester", "senior", new Bonus(3000, 3)),
                }
            ),
            new Department(
                "Development",
                "Chicago",
                new List<Person>
                {
                    new Person("Peter", 30, "developer", "senior", new Bonus(4000, 4)),
                    new Person("Kate", 23, "ux designer", "junior", new Bonus(1000, 1)),
                    new Person("Jack", 20, "developer", "junior", new Bonus(1000, 1)),
                    new Person("Susan", 27, "developer", "medior", new Bonus(3000, 3)),
                }
            ),
        };

        #region Komplikáltabb adatszerkezet kiírása fájlba

        XDocument departmentsDoc = new XDocument();
        XElement departmentsRoot = new XElement("departments");
        departmentsDoc.Add(departmentsRoot);

        departmentsRoot.Add(
            departments.Select(department => new XElement(
                "department",
                new XElement("name", department.Name),
                new XElement("location", department.Location),
                new XElement(
                    "employees",
                    department.Employees.Select(worker => new XElement(
                        "employee",
                        new XElement("name", worker.Name),
                        new XElement("age", worker.Age),
                        new XElement("profession", worker.Profession),
                        new XElement("level", worker.Level),
                        new XElement(
                            "bonus",
                            new XElement("amount", worker.Bonus.Amount),
                            new XElement("frequency", worker.Bonus.Frequency)
                        )
                    ))
                )
            ))
        );

        departmentsDoc.Save("departments.xml");
        #endregion

        #region Kiírás segéd metódusokkal

        XDocument departmentsDoc2 = new XDocument();
        XElement departmentsRoot2 = new XElement("departments");
        departmentsDoc2.Add(departmentsRoot2);

        departmentsRoot2.Add(departments.Select(department => department.ToXml()));

        #endregion
    }
}
