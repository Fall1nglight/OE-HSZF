using System.Reflection;
using System.Xml.Serialization;

namespace Lab_3;

class Program
{
    static void Main(string[] args)
    {
        XmlSerializer reader = new XmlSerializer(typeof(ProductPackage));
        using (StreamReader file = new StreamReader("products.xml"))
        {
            ProductPackage package = (ProductPackage)reader.Deserialize(file)!;

            List<Product> validProducts = package
                .Categories.SelectMany(cat => cat.Products)
                .Where(Validator.IsValid)
                .ToList();
        }
    }
}
