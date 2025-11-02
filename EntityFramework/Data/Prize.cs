using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Data;

public class Prize
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<PersonPrize> PersonPrizes { get; set; } = [];
}
