using System.Xml.Serialization;

namespace Lab_3;

[XmlRoot("ProductPackage")]
public class ProductPackage
{
    public List<Category> Categories { get; set; }
}
