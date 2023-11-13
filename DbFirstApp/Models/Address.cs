using System;
using System.Collections.Generic;

namespace DbFirstApp.Models;

public class Address
{
    public int Id { get; set; }

    public string AddressString { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
