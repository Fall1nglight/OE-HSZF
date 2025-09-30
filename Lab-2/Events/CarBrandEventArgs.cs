namespace Lab_2.Events;

public class CarBrandEventArgs : EventArgs
{
    public string Brand;
    public int Count;

    public CarBrandEventArgs(string brand, int count)
    {
        Brand = brand;
        Count = count;
    }
}
