namespace Lab_2;

public class CarFinancial
{
    public static decimal Analyze(Func<Car, decimal> operation, Car[] cars)
    {
        decimal result = 0;

        foreach (var car in cars)
        {
            result += operation(car);
        }

        return result;
    }
}
