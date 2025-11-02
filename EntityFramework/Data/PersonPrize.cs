namespace EntityFramework.Data;

public class PersonPrize
{
    public int PersonId { get; set; }
    public int PrizeId { get; set; }
    public Person Person { get; set; } = null!;
    public Prize Prize { get; set; } = null!;
}
