﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodStore.Models;


public partial class Product
{
    public string ProductID { get; set; } = null!;
    
    public string ProductName { get; set; } = null!;
 
    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string Picture { get; set; } = null!;

    public string CateID { get; set; } = null!;

    public virtual Category Cate { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetail { get; set; } = new List<OrderDetail>();
}