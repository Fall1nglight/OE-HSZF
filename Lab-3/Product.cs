namespace Lab_3;

public class Product
{
    [RequiredNonEmpty]
    public string Sku { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}
