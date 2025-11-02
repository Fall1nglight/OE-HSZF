using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Attributes;

[Serializable]
public class Dog
{
    [Required]
    [StringLength(10)]
    [DisplayName("Név")]
    public string Name { get; set; }

    [Required]
    [Range(1, 20)]
    [DisplayName("Kor")]
    public int Age { get; set; }

    [StringLength(100)]
    [DisplayName("Gazdi")]
    public string OwnerName { get; set; }

    [StringLength(20)]
    [DisplayName("Szín")]
    public string Color { get; set; }
}
