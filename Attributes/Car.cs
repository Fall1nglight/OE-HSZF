using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Attributes;

public class Car
{
    [Length(3, 15)]
    [StartUpperCase]
    public string Brand { get; set; }

    [Length(3, 25)]
    [StartUpperCase]
    public string Model { get; set; }

    [Length(1, 15)]
    public string Color { get; set; }
}
