using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Des { get; set; } = null!;

    public string? Image { get; set; }

    public virtual Category Category { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
}
