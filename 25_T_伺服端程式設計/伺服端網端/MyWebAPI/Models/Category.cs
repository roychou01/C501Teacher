using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyWebAPI.Models;

public partial class Category
{
    public string CateID { get; set; } = null!;

    public string CateName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Product> Product { get; set; } = new List<Product>();
}
