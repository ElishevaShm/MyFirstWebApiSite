using System;
using System.Collections.Generic;

namespace Entity;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Des { get; set; } = null!;

    public string? Image { get; set; }

    public virtual Category Category { get; set; } = null!;
}
