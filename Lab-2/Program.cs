using System.Text;

namespace Lab_2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            CarService carService = new CarService();

            carService.CarBrand += (obj, evArgs) =>
            {
                Console.WriteLine(
                    $"A {evArgs.Brand} típusból {evArgs.Count} darab lett beolvasva."
                );
            };

            carService.ParseFromFile("autok.txt");

            // LINQ
            // 1.
            var carsDescOrderByPrice = carService.Cars.OrderByDescending(car => car.Price);

            // 2.
            var cheapestCar = carService.Cars.Min(car => car.Price);

            // 3.
            var mostExpensiveCar = carService.Cars.Max(car => car.Price);

            // 4.
            var anonymousDetails = carService.Cars.Select(car => new
            {
                BrandModel = $"{car.Brand} -  {car.Model}",
                Year = car.Year,
                Age = DateTime.Now.Year - car.Year,
            });

            // 5.
            var brandGrouping = carService
                .Cars.GroupBy(car => car.Brand)
                .Select(car => new
                {
                    Brand = car.Key,
                    Count = car.Count(),
                    AvgPrice = car.Average(carx => carx.Price),
                })
                .OrderByDescending(car => car.Count)
                .ThenByDescending(car => car.AvgPrice);

            // 6.
            decimal SumPriceOfYear(int year) =>
                CarFinancial.Analyze(
                    car => car.Year == year ? car.Price : 0,
                    carService.Cars.ToArray()
                );

            int year = 2016;
            decimal resultOfSum = SumPriceOfYear(year);

            Directory.CreateDirectory(year.ToString());

            using StreamWriter sw = new StreamWriter(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    year.ToString(),
                    $"{DateTime.Now:yyyy-MM-dd}.txt"
                )
            );

            sw.WriteLine($"A {year} évjáratú autók összértéke: {resultOfSum}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Hiba történt beolvasás közben: {e.Message}");
            throw;
        }
    }
}
