using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Data;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Job { get; set; }

    [Range(1, 100)]
    public int Age { get; set; }

    public List<Review> Reviews { get; set; } = [];
    public List<PersonPrize> PersonPrizes { get; set; } = [];
}
