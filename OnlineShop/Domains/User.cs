﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mapster;

namespace OnlineShop.Domains;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public UserType UserType { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}