using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Data;

public class Review
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public string Text { get; set; }

    [Range(1, 5)]
    public int Mark { get; set; }

    public Person Person { get; set; } = null!;
}
