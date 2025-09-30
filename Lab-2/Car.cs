namespace Lab_2;

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Price { get; set; }

    public Car(string brand, string model, int year, int price)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }
}
