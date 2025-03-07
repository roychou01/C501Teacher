﻿using System;
using System.Collections.Generic;

namespace MyWebAPI.Models;

public partial class Member
{
    public string MemberID { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool Gender { get; set; }

    public int Point { get; set; }

    public string Account { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Order { get; set; } = new List<Order>();
}
